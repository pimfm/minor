using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Infrastructure.DataAccessLayer
{
    public class CourseAdministrationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public CourseAdministrationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey(course => course.ID);
            modelBuilder.Entity<Course>().Property(course => course.Title).IsRequired();
        }
    }
}