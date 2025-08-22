using Microsoft.EntityFrameworkCore;
using dz3.Entities;
using dz3.Data;

namespace dz3 {
    public class AppDbContext : DbContext {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string connectionString = "workstation id=testDB12345.mssql.somee.com;packet size=4096;user id=axneo27_SQLLogin_1;pwd=qwertyqwerty;data source=testDB12345.mssql.somee.com;persist security info=False;initial catalog=testDB12345;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameGenres"));
            
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PublisherId);
        }
    }
}