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
using GradesApp.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using GradesApp.Services;


namespace GradesApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<IdentityUser> _userManager;

        public TeachersController(ITeacherService teacherService, UserManager<IdentityUser> userManager, ISubjectService subjectService)
        {
            _teacherService = teacherService;
            _userManager = userManager;
            _subjectService = subjectService;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _teacherService.GetAllAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _teacherService.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Teachers/Create
        [Authorize(Roles = "Admin")]
        public async Task< IActionResult> Create()
        {
            var subjects = await _subjectService.GetAllAsync();

            var teacherCreateDto = new TeacherCreateDTO
            {
                Subjects = subjects.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList()
            };

            return View(teacherCreateDto);
           
        }


        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TeacherCreateDTO teacherCreateDto)
        {
            if (!ModelState.IsValid)
            {
                teacherCreateDto.Subjects = (await _subjectService.GetAllAsync())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                    .ToList();

                return View(teacherCreateDto);
            }

            try
            {
                await _teacherService.CreateAsync(teacherCreateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", "An unexpected error occurred.");
                return View(teacherCreateDto);
            }
            
        }

        // GET: Teachers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.GetByIdAsync(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            var subjects = await _subjectService.GetAllAsync(); 

            var teacherEditDto = new TeacherEditDTO
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Birthday = teacher.Birthday,
                Email = teacher.Email,
                SubjectId = teacher.Subject.Id,
                AccountId = teacher.AccountId,
                Subjects = subjects.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList()
            };

            return View(teacherEditDto);

        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, TeacherEditDTO teacherEditDto)
        {
            if (id != teacherEditDto.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                teacherEditDto.Subjects = (await _subjectService.GetAllAsync())
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                    .ToList();
                var teacher = await _teacherService.GetByIdAsync(teacherEditDto.Id);
               return View(teacherEditDto);
            }
            try
            {
                await _teacherService.UpdateAsync(teacherEditDto);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TeacherExistsAsync(teacherEditDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // GET: Teachers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.GetByIdAsync(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _teacherService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TeacherExistsAsync(int id)
        {
            return await _teacherService.GetByIdAsync(id) != null;
        }
    }
}
