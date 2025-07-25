using System.ComponentModel.DataAnnotations;

namespace dz1.Entities {
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Studio { get; set; }

        public string Style { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        public string GameMode { get; set; }  // added
        public int SoldCopies { get; set; }  // added
        
    }
}