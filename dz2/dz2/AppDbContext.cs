using Microsoft.EntityFrameworkCore;
using dz2.Entities;

namespace dz2 {
    public class AppDbContext : DbContext {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCard> StudentCards { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string connectionString = "workstation id=testDB12345.mssql.somee.com;packet size=4096;user id=axneo27_SQLLogin_1;pwd=qwertyqwerty;data source=testDB12345.mssql.somee.com;persist security info=False;initial catalog=testDB12345;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentCard)
                .WithOne(sc => sc.Student)
                .HasForeignKey<StudentCard>(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<StudentCard>()
                .HasOne(sc => sc.Student)
                .WithOne(s => s.StudentCard)
                .HasForeignKey<Student>(s => s.StudentCardId);
            
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<StudentsCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            //Seeding
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "John Doe", Subject = "Mathematics" },
                new Teacher { Id = 2, Name = "Jane Smith", Subject = "Physics" }
            );

            var courses = new List<Course> {
                new Course { Id = 1, Title = "Calculus", Description = "An introduction to calculus.", Credits = 3, TeacherId = 1 },
                new Course { Id = 2, Title = "Physics I", Description = "Fundamentals of physics.", Credits = 4, TeacherId = 2 },
                new Course { Id = 3, Title = "Chemistry", Description = "Basic principles of chemistry.", Credits = 3, TeacherId = 1 },
                new Course { Id = 4, Title = "Biology", Description = "Introduction to biology.", Credits = 3, TeacherId = 2 }
            };
            modelBuilder.Entity<Course>().HasData(courses);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson", StudentCardId = 1 },
                new Student { Id = 2, Name = "Bob Brown", StudentCardId = 2 },
                new Student { Id = 3, Name = "Charlie Davis", StudentCardId = 3 },
                new Student { Id = 4, Name = "Diana Evans", StudentCardId = 4 },
                new Student { Id = 5, Name = "Ethan Green", StudentCardId = 5 }
            );

            modelBuilder.Entity<StudentCard>().HasData(
                new StudentCard { Id = 1, CardNumber = "SC12345", StudentId = 1 },
                new StudentCard { Id = 2, CardNumber = "SC67890", StudentId = 2 },
                new StudentCard { Id = 3, CardNumber = "SC11223", StudentId = 3 },
                new StudentCard { Id = 4, CardNumber = "SC44556", StudentId = 4 },
                new StudentCard { Id = 5, CardNumber = "SC78901", StudentId = 5 }
            );

            modelBuilder.Entity<StudentsCourses>().HasData(
                new StudentsCourses { StudentId = 1, CourseId = 1 },
                new StudentsCourses { StudentId = 2, CourseId = 2 },
                new StudentsCourses { StudentId = 3, CourseId = 3 },
                new StudentsCourses { StudentId = 4, CourseId = 4 },
                new StudentsCourses { StudentId = 5, CourseId = 1 },
                new StudentsCourses { StudentId = 1, CourseId = 2 },
                new StudentsCourses { StudentId = 2, CourseId = 3 },
                new StudentsCourses { StudentId = 3, CourseId = 4 }
            );

        }
    }
}