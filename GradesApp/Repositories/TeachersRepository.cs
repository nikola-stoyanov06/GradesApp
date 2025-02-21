using GradesApp.Data;
using GradesApp.Data.Entities;
using GradesApp.Repositories.Abstarctions;

namespace GradesApp.Repositories
{
    public class TeachersRepository : CrudRepository<Teacher>, ITeachersRepository
    {
        private readonly ApplicationDbContext _context;

        public TeachersRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
