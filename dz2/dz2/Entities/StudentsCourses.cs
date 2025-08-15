using System.ComponentModel.DataAnnotations;

namespace dz2.Entities { 
    public class StudentsCourses {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}