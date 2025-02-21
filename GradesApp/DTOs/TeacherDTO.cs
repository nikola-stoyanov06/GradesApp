using GradesApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.DTOs
{
    public class TeacherDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public SubjectDTO Subject { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
