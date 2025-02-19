namespace GradesApp.Data.Entities
{
    public class Grade : BaseEntity
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public double Value { get; set; }
    }
}
