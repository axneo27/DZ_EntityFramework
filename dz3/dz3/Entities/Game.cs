using System.ComponentModel.DataAnnotations;

namespace dz3.Entities {
    public class Game { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        //genres
        public virtual ICollection<Genre> Genres { get; set; }
        //publisher
        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
}