using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Infrastructure.DataAccessLayer
{
    public class CourseAdministrationDbContext : DbContext
    {
        public DbSet<CourseMoment> CourseMoments { get; set; }

        public CourseAdministrationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}