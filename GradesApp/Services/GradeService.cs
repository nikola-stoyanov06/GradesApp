using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;
using GradesApp.Repositories.Abstarctions;
using GradesApp.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.Services
{
    public class GradeService : IGradeService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public GradeService(IStudentsRepository studentsRepository, IGradeRepository gradeRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _studentsRepository = studentsRepository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task CreateAsync(CreateGradeDTO gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            await _gradeRepository.CreateAsync(grade);
        }

        public async Task DeleteAsync(int gradeId)
        {
            await _gradeRepository.DeleteByIdAsync(gradeId);
        }

        public async Task<ICollection<GradeDTO>> GetAllAsync()
        {
            var grades = await _gradeRepository.GetAllAsync();
            return _mapper.Map<ICollection<GradeDTO>>(grades);
        }

        public async Task<GradeDTO> GetByIdAsync(int id)
        {
            var grade = await _gradeRepository.GetByIdAsync(id);
            return _mapper.Map<GradeDTO>(grade);
        }

        public async Task UpdateAsync(CreateGradeDTO gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            await _gradeRepository.UpdateAsync(grade);
        }
    }
}
