using Microsoft.AspNetCore.Identity;

namespace GradesApp.Data.Entities
{
    public class Teacher : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual IdentityUser? Account { get; set; }
        public string AccountId { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
