using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Infrastructure.DataAccessLayer
{
    public class CourseAdministrationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseMoment> CourseMoments { get; set; }

        public CourseAdministrationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey(course => course.ID);
            modelBuilder.Entity<Course>().Property(course => course.Title).IsRequired();
            modelBuilder.Entity<Course>().Property(course => course.Code).IsRequired();
            modelBuilder.Entity<Course>().Property(course => course.DurationInDays).IsRequired();

            modelBuilder.Entity<CourseMoment>().ToTable("CourseMoment");
            modelBuilder.Entity<CourseMoment>().HasKey(courseMoment => courseMoment.ID);
            modelBuilder.Entity<CourseMoment>().Property(courseMoment => courseMoment.StartDate).IsRequired();
        }
    }
}