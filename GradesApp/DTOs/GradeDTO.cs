using GradesApp.Data.Entities;

namespace GradesApp.DTOs
{
    public class GradeDTO : BaseDTO
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public double Value { get; set; }
    }
}
