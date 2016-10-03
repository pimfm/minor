using DatabaseCodeFirst.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCodeFirst.Infrastructure.Database
{
    public class PartyContext : DbContext
    {
        public DbSet<Festival> Festivals { get; set; }

        public PartyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FestivalDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>()
                .Property(festival => festival.Title)
                .IsRequired();
        }
    }
}
