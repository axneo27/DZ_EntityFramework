using System.ComponentModel.DataAnnotations;

namespace dz2.Entities {
    public class Course {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}