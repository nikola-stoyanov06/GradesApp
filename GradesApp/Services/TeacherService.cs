using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;
using GradesApp.Repositories.Abstarctions;
using GradesApp.Services.Abstractions;

namespace GradesApp.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        private IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TeacherDTO teacherDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherDto);
            await _teacherRepository.CreateAsync(teacher);
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

        public async Task UpdateAsync(TeacherDTO teacherDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherDto);
            await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
