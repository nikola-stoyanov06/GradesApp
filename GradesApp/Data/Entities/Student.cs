using Microsoft.AspNetCore.Identity;

namespace GradesApp.Data.Entities
{
    public class Student : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
        public string? AccountId { get; set; }
        public virtual IdentityUser? Account { get; set; }
    }
}
