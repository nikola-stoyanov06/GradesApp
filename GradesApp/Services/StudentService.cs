using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;
using GradesApp.Repositories;
using GradesApp.Repositories.Abstarctions;
using GradesApp.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentService(IStudentsRepository studentsRepository, IGradeRepository gradeRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _studentsRepository = studentsRepository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        /*public async Task AddStudentGradeAsync(StudentGradeDTO studentGradeDTO)
        {
            var grade = _mapper.Map<Grade>(studentGradeDTO);
            await _gradeRepository.CreateAsync(grade);
        }*/

        public async Task CreateAsync(StudentDTO studentDTO)
        {
            Student student = _mapper.Map<Student>(studentDTO);

            var studentUser = new IdentityUser()
            {
                Email = student.Email,
                UserName = student.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(studentUser, "Student!123");

            if (result.Succeeded)
            {
                student.AccountId = studentUser.Id;
                await _userManager.AddToRoleAsync(studentUser, "Student");
                await _studentsRepository.CreateAsync(student);
            }
            else
            {
                throw new InvalidOperationException(result.Errors.First().Description.ToString());
            }
        }

        public async Task DeleteAsync(int studentId)
        {
            await _studentsRepository.DeleteByIdAsync(studentId);
        }

        public async Task<ICollection<StudentDTO>> GetAllAsync()
        {
            var students = await _studentsRepository.GetAllAsync();
            return _mapper.Map<ICollection<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _studentsRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public ICollection<StudentDTO> GetByName(string name)
        {
            var students = _studentsRepository.GetByFilter(student => student.FirstName == name
                || student.LastName == name);
            return _mapper.Map<ICollection<StudentDTO>>(students);
        }

        public async Task UpdateAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentsRepository.UpdateAsync(student);
        }
    }
}
