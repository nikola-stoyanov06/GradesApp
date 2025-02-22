using GradesApp.DTOs;

namespace GradesApp.Services.Abstractions
{
    public interface IGradeService
    {
        Task<GradeDTO> GetByIdAsync(int id);
        Task<ICollection<GradeDTO>> GetAllAsync();
        Task CreateAsync(CreateGradeDTO gradeDto);
        Task UpdateAsync(CreateGradeDTO gradeDto);
        Task DeleteAsync(int gradeId);
    }
}
