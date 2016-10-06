using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Infrastructure.DataAccessLayer
{
    public class SupermarketDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}