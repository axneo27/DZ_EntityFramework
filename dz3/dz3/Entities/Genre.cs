namespace dz3.Entities {
    public class Genre { 
        public int Id { get; set; }
        public string Name { get; set; }
        //games
        public virtual ICollection<Game> Games { get; set; }
    }
}