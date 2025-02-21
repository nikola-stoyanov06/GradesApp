namespace GradesApp.Data.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
