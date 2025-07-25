using Microsoft.EntityFrameworkCore;
using dz1.Entities;

namespace dz1 {
    public class AppDbConnect : DbContext {

        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string connectionString = "....";
            //workstation id=testDB12345.mssql.somee.com;packet size=4096;user id=axneo27_SQLLogin_1;pwd={};data source=testDB12345.mssql.somee.com;persist security info=False;initial catalog=testDB12345;TrustServerCertificate=True (ON SOMEE.COM)
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}