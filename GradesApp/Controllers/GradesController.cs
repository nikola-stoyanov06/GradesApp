using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GradesApp.DTOs;
using NuGet.DependencyResolver;
using AutoMapper;
using Humanizer;


namespace GradesApp.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;


        public GradesController(IMapper mapper, IStudentService studentService, IGradeService gradeService, ITeacherService teacherService, UserManager<IdentityUser> userManager, ISubjectService subjectService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _gradeService = gradeService;
            _teacherService = teacherService;
            _userManager = userManager;
            _subjectService = subjectService;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            return View(await _gradeService.GetAllAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _gradeService.GetByIdAsync(id.Value);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }
        [Authorize(Roles = "Teacher")]
        // GET: Grades/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var teacher = _teacherService.GetByAccountId(user.Id).First();
            var students = await _studentService.GetAllAsync();
            var createDTO = new CreateGradeDTO 
            {
                Students = students.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.FirstName + " " + s.LastName,
                }).ToList(),
                TeacherId = teacher.Id,
                SubjectId = teacher.Subject.Id
            };
            return View(createDTO);
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(CreateGradeDTO gradeDTO)
        {
            if (!ModelState.IsValid)
            {
                gradeDTO.Students = (await _studentService.GetAllAsync())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), 
                        Text = s.FirstName + " " + s.LastName })
                    .ToList();

                return View(gradeDTO);
            }

            try
            {
                await _gradeService.CreateAsync(gradeDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", "An unexpected error occurred.");
                return View(gradeDTO);
            }

        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var grade = await _gradeService.GetByIdAsync(id.Value);
            
            if (grade == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<CreateGradeDTO>(grade);
            var students = await _studentService.GetAllAsync();
            dto.Students = students.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.FirstName} {s.LastName}"
            }).ToList();
            return View(dto);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateGradeDTO gradeDTO)
        {
            if (id != gradeDTO.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                gradeDTO.Students = (await _studentService.GetAllAsync())
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.FirstName + " " + s.LastName
                    })
                    .ToList();

                return View(gradeDTO);
            }

            try
            {
                await _gradeService.UpdateAsync(gradeDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", "An unexpected error occurred.");
                return View(gradeDTO);
            }
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _gradeService.GetByIdAsync(id.Value);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gradeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _gradeService.GetByIdAsync(id) != null;
        }
    }
}
