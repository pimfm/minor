using Microsoft.EntityFrameworkCore;
using MonumentBackend.DataAccessLayer;
using MonumentBackend.Entities;
using MonumentBackend.Factories;

namespace MonumentBackend.Repositories
{
    public class MonumentRepository : BaseRepository<Monument, MonumentContext>
    {
        private ContextFactory<MonumentContext> _factory = new ContextFactory<MonumentContext>();

        public override DbSet<Monument> ProvideDatabaseSet()
        {
            using (MonumentContext context = _factory.ManufactureContext())
            {
                return context.Monuments;
            }
        }
    }
}