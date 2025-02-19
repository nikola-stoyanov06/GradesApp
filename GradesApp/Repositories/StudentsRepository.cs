using GradesApp.Data;

namespace GradesApp.Repositories
{
    public class StudentsRepository : CrudRepository<Student>, IStudentsRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
