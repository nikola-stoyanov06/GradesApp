namespace GradesApp.Services.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<ICollection<TeacherDTO>> GetAllAsync();
        Task CreateAsync(TeacherDTO TeacherDto);
        Task UpdateAsync(TeacherDTO TeacherDto);
        Task DeleteAsync(int TeacherId);
        ICollection<TeacherDTO> GetByName(string name);
    }
}
