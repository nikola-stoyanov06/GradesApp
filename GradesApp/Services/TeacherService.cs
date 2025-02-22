using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;
using GradesApp.Repositories.Abstarctions;
using GradesApp.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        private UserManager<IdentityUser> _userManager;
        private IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(TeacherCreateDTO teacherCreateDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherCreateDto);

            var teacherUser = new IdentityUser()
            {
                Email = teacher.Email,
                UserName = teacher.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(teacherUser, "Teacher!123");

            if (result.Succeeded)
            {
                teacher.AccountId = teacherUser.Id;
                await _userManager.AddToRoleAsync(teacherUser, "Teacher");
                await _teacherRepository.CreateAsync(teacher);
            }
            else
            {
                throw new InvalidOperationException(result.Errors.First().Description.ToString());
            }
        }

        public async Task DeleteAsync(int teacherId)
        {
            await _teacherRepository.DeleteByIdAsync(teacherId);
        }

        public async Task<ICollection<TeacherDTO>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<ICollection<TeacherDTO>>(teachers);
        }

        public async Task<TeacherDTO> GetByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return _mapper.Map<TeacherDTO>(teacher);
        }

        public ICollection<TeacherDTO> GetByName(string name)
        {
            var teachers = _teacherRepository
                .GetByFilter(teacher => teacher.FirstName == name
                    || teacher.LastName == name);
            return _mapper.Map<ICollection<TeacherDTO>>(teachers);
        }
        public ICollection<TeacherDTO> GetByAccountId(string id)
        {
            var teachers = _teacherRepository
                .GetByFilter(teacher => teacher.AccountId == id);
            return _mapper.Map<ICollection<TeacherDTO>>(teachers);
        }

        public async Task UpdateAsync(TeacherEditDTO teacherEditDto)
        { 
            Teacher teacher = _mapper.Map<Teacher>(teacherEditDto);
            await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
