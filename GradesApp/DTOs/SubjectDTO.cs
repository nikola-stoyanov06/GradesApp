using GradesApp.Data.Entities;

namespace GradesApp.DTOs
{
    public class SubjectDTO : BaseDTO
    {
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
