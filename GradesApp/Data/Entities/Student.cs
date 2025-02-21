using Microsoft.AspNetCore.Identity;

namespace GradesApp.Data.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Class { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public IdentityUser User { get; set; }
    }
}
