using GradesApp.DTOs;

namespace GradesApp.Services.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<ICollection<TeacherDTO>> GetAllAsync();
        Task CreateAsync(TeacherCreateDTO teacherCreateDto);
        Task UpdateAsync(TeacherEditDTO teacherEditDto);
        Task DeleteAsync(int teacherId);
        ICollection<TeacherDTO> GetByName(string name);
        ICollection<TeacherDTO> GetByAccountId(string id);
    }
}
