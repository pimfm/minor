using DatabaseCodeFirst.Core.Entities;
using DatabaseCodeFirst.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DatabaseCodeFirst.Application.Repositories
{
    public class FestivalRepository : PartyBaseRepository<Festival, int>
    {
        public override Festival Find(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Festival> FindAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Festival> FindBy(Expression<Func<Festival, bool>> File)
        {
            throw new NotImplementedException();
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
