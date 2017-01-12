using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace TestMicroService.DAL.Repositories
{
    public class ExampleContext : DbContext
    {
        public virtual DbSet<Example> Examples { get; set; }

        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          if(!optionsBuilder.IsConfigured)
            {
                throw new Exception("No Database Setup!");
            }
        }
    }
}