using Application.Factories;
using DatabaseCodeFirst.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseCodeFirst.Application.Repositories
{
    public abstract class PartyBaseRepository<Entity, Key> : IRepository<Entity, Key>
        where Entity : class
    {
        private ContextFactory<PartyContext> _factory;

        public PartyBaseRepository(ContextFactory<PartyContext> factory)
        {
            _factory = factory;
        }

        public abstract DbSet<Entity> ProvideDatabaseSet();
        public abstract Entity Find(Key id);
        public abstract IEnumerable<Entity> FindAll();
        public abstract IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter);

        public int Count()
        {
            using (PartyContext context = _factory.MakeContext())
            {
                return ProvideDatabaseSet().Count();
            }
        }

        public void Insert(Entity item)
        {
            using (PartyContext context = new PartyContext())
            {
                ProvideDatabaseSet().Add(item);
            }
        }

        public void Update(Entity item)
        {
            using (PartyContext context = new PartyContext())
            {
                ProvideDatabaseSet().Update(item);
            }
        }

        public void Delete(Entity item)
        {
            using (PartyContext context = new PartyContext())
            {
                ProvideDatabaseSet().Remove(item);
            }
        }
    }
}
