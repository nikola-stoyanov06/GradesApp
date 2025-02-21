using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Repositories.Abstarctions;

namespace GradesApp.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
        }
    }
}
