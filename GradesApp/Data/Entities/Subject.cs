namespace GradesApp.Data.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
