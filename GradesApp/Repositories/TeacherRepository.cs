using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Repositories.Abstarctions;

namespace GradesApp.Repositories
{
    public class TeacherRepository : CrudRepository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
