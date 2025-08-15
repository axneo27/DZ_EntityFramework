using System.ComponentModel.DataAnnotations;

namespace dz2.Entities {
    public class Teacher {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}