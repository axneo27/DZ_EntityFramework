using System.ComponentModel.DataAnnotations;

namespace dz2.Entities { 
    public class StudentCard {
        [Key]
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
    }
}