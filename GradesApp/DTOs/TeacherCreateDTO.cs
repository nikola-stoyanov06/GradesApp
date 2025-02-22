using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace GradesApp.DTOs
{
    public class TeacherCreateDTO : BaseDTO
    {
        public string Email { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<SelectListItem>? Subjects { get; set; }
    }
}
