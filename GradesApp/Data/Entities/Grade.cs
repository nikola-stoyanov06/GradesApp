namespace GradesApp.Data.Entities
{
    public class Grade : BaseEntity
    {
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
