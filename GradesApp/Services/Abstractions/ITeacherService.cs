using GradesApp.DTOs;

namespace GradesApp.Services.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<ICollection<TeacherDTO>> GetAllAsync();
        Task CreateAsync(TeacherDTO teacherDto);
        Task UpdateAsync(TeacherDTO teacherDto);
        Task DeleteAsync(int teacherId);
        ICollection<TeacherDTO> GetByName(string name);
    }
}
