using Microsoft.EntityFrameworkCore;

namespace DatabaseCodeFirst.Infrastructure.DataAccessLayer
{
    public class FestivalContext : DbContext
    {
        public FestivalContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;FestivalDatabase=;Trusted_Connection=True;");
        }
    }
}
