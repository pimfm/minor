using Microsoft.EntityFrameworkCore;
using MonumentBackend.Entities;

namespace MonumentBackend.DataAccessLayer
{
    public class MonumentContext : DbContext
    {
        public DbSet<Monument> Monuments { get; set; }
    }
}