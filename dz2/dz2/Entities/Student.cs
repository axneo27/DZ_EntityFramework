using System.ComponentModel.DataAnnotations;

namespace dz2.Entities { 
    public class Student {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentCard? StudentCard { get; set; }
        public int StudentCardId { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}