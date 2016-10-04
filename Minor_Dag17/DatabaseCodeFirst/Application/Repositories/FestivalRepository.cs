using DatabaseCodeFirst.Application.Factories;
using DatabaseCodeFirst.Core.Entities;
using DatabaseCodeFirst.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseCodeFirst.Application.Repositories
{
    public class FestivalRepository : BaseRepository<Festival, ContextFactory<PartyContext>, PartyContext>, EntityFinder<Festival, int>
    {
        public FestivalRepository(ContextFactory<PartyContext> factory) : base(factory)
        {
        }

        public Festival Find(int key)
        {
            using (PartyContext context = new PartyContext())
            {
                return context.Festivals.FirstOrDefault(festival => festival.Id == key);
            }
        }

        public override DbSet<Festival> ProvideDatabaseSet()
        {
            using(PartyContext context = new PartyContext())
            {
                return context.Festivals;
            }
        }
    }
}
