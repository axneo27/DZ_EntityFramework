namespace dz3.Entities { 
    public class Publisher { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Founded { get; set; }
        public string Website { get; set; }

        //games
        public virtual ICollection<Game> Games { get; set; }
    }
}