using GradesApp.DTOs;

namespace GradesApp.Services.Abstractions
{
    public interface IStudentService
    {
        Task<StudentDTO> GetByIdAsync(int id);
        Task<ICollection<StudentDTO>> GetAllAsync();
        Task CreateAsync(StudentDTO studentDto);
        Task UpdateAsync(StudentDTO studentDto);
        Task DeleteAsync(int studentId);
        ICollection<StudentDTO> GetByName(string name);
    }
}
