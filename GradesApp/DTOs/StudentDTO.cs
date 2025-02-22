using GradesApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.DTOs
{
    public class StudentDTO : BaseDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Class { get; set; }
        public ICollection<Grade>? Grades { get; set; }
        public IdentityUser? User { get; set; }
        public string? UserId { get; set; }
    }
}
