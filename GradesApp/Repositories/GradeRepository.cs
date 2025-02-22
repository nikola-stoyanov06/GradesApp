using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Repositories.Abstarctions;

namespace GradesApp.Repositories
{
    public class GradeRepository : CrudRepository<Grade>, IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
