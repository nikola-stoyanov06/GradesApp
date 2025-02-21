using GradesApp.DTOs;

namespace GradesApp.Services.Abstractions
{
    public interface ISubjectService
    {
        Task<SubjectDTO> GetByIdAsync(int id);
        Task<ICollection<SubjectDTO>> GetAllAsync();
        Task CreateAsync(SubjectDTO subjectDto);
        Task UpdateAsync(SubjectDTO subjectDto);
        Task DeleteAsync(int subjectId);
        ICollection<SubjectDTO> GetByName(string name);
    }
}