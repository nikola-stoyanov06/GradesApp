using GradesApp.Data.Entities;

namespace GradesApp.Repositories.Abstarctions
{
    public interface IGradeRepository
    {
        Task CreateAsync(Grade grade);
    }
}
