using Microsoft.AspNetCore.Identity;

namespace GradesApp.Data.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
