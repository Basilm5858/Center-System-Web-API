using CENTER_MANAGEMENT_SYSTEM.Enums;
using Microsoft.EntityFrameworkCore;

namespace CENTER_MANAGEMENT_SYSTEM.Models
{
    public class My_AppContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CenterDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseCategory>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Instructor>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Enrollment>().HasIndex(x => new { x.CourseId, x.StudentId }).IsUnique();

            modelBuilder.Entity<Course>().Property(x => x.Fee).HasPrecision(10, 2);
            modelBuilder.Entity<Student>().Property(x => x.RegistrationDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Enrollment>().Property(x => x.EnrollmentDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Course>().Property(x => x.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Enrollments)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Instructor>()
                .HasMany(x => x.Courses)
                .WithOne(x => x.Instructor)
                .HasForeignKey(x => x.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<CourseCategory>()
                .HasMany(x => x.Courses)
                .WithOne(x => x.CourseCategory)
                .HasForeignKey(x => x.CourseCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasOne(x => x.CourseCategory)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.CourseCategoryId);
            
            modelBuilder.Entity<Course>()
                .HasOne(x => x.Instructor)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.InstructorId);

            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, Email = "basil@gmail.com", FullName = "Basil Mohamed", PhoneNumber = "01158589063", RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, Email = "ahmed@gmail.com", FullName = "Ahmed Mohamed", PhoneNumber = "01158589013", RegistrationDate = DateTime.Now });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 3, Email = "mohamed@gmail.com", FullName = "Mohamed Lotfy", PhoneNumber = "01158589033", RegistrationDate = DateTime.Now });

            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 1, Email = "fady@gmail.com", FullName = "Fady Mohamed", Specialization = "CS", HireDate = DateTime.Now });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 2, Email = "hamada@gmail.com", FullName = "Hamada Mohamed", Specialization = "CS", HireDate = DateTime.Now });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 3, Email = "yara@gmail.com", FullName = "Yara Mohamed", Specialization = "ES", HireDate = DateTime.Now });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { Id = 4, Email = "nour@gmail.com", FullName = "Nour Mohamed", Specialization = "ES", HireDate = DateTime.Now });

            modelBuilder.Entity<CourseCategory>().HasData(new CourseCategory { Id = 1, Description = "This Is Category 1", Name = "Category 1" });
            modelBuilder.Entity<CourseCategory>().HasData(new CourseCategory { Id = 2, Description = "This Is Category 2", Name = "Category 2" });
            modelBuilder.Entity<CourseCategory>().HasData(new CourseCategory { Id = 3, Description = "This Is Category 3", Name = "Category 3" });

            modelBuilder.Entity<Course>().HasData(
                   new Course
                   {
                       Id = 1,
                       Title = "ASP.NET Core Web API",
                       DurationHours = 40,
                       Fee = 2500m,
                       Capacity = 25,
                       IsActive = true,
                       CourseCategoryId = 1,
                       InstructorId = 1
                   },
                   new Course
                   {
                       Id = 2,
                       Title = "C# Fundamentals",
                       DurationHours = 30,
                       Fee = 1800m,
                       Capacity = 30,
                       IsActive = true,
                       CourseCategoryId = 1,
                       InstructorId = 2
                   },
                   new Course
                   {
                       Id = 3,
                       Title = "SQL Server",
                       DurationHours = 35,
                       Fee = 2000m,
                       Capacity = 20,
                       IsActive = true,
                       CourseCategoryId = 2,
                       InstructorId = 3
                   },
                   new Course
                   {
                       Id = 4,
                       Title = "Database Fundamentals",
                       DurationHours = 25,
                       Fee = 1500m,
                       Capacity = 25,
                       IsActive = false,
                       CourseCategoryId = 2,
                       InstructorId = 1
                   },
                   new Course
                   {
                       Id = 5,
                       Title = "Network Fundamentals",
                       DurationHours = 45,
                       Fee = 3000m,
                       Capacity = 15,
                       IsActive = true,
                       CourseCategoryId = 3,
                       InstructorId = 3
                   },
                   new Course
                   {
                       Id = 6,
                       Title = "Frontend Development",
                       DurationHours = 50,
                       Fee = 3500m,
                       Capacity = 30,
                       IsActive = true,
                       CourseCategoryId = 3,
                       InstructorId = 2
                   }
               );
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 1, Status = EnrollmentStatus.Active, StudentId = 1, EnrollmentDate = DateTime.Now, CourseId = 1, Grade = 100 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 2, Status = EnrollmentStatus.Active, StudentId = 2, EnrollmentDate = DateTime.Now, CourseId = 1, Grade = 70 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 3, Status = EnrollmentStatus.Active, StudentId = 3, EnrollmentDate = DateTime.Now, CourseId = 2, Grade = 50 });
            modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 4, Status = EnrollmentStatus.Active, StudentId = 3, EnrollmentDate = DateTime.Now, CourseId = 3, Grade = 30 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
