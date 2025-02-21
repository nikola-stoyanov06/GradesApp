using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Repositories.Abstarctions;

namespace GradesApp.Repositories
{
    public class SubjectRepository : CrudRepository<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
