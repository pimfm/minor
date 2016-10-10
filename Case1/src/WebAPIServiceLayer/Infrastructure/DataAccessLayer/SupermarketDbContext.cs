using Microsoft.EntityFrameworkCore;
using BackendService.Domain.Entities;

namespace BackendService.Infrastructure.DataAccessLayer
{
    public class SupermarketDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SupermarketDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasKey(product => product.ID);
            modelBuilder.Entity<Product>().Property(product => product.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.Price).IsRequired();
        }
    }
}