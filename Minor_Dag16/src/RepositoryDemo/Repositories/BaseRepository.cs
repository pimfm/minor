using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Infrastructure.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryDemo.Repositories
{
    public abstract class BaseRepository<Entity, Key> : IRepository<Entity, Key>
        where Entity : class
    {
        public abstract DbSet<Entity> ProvideDatabaseSet();
        public abstract Entity Find(Key id);
        public abstract IEnumerable<Entity> FindAll();
        public abstract IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter);

        public void Insert(Entity item)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                ProvideDatabaseSet().Add(item);
            }
        }

        public void Update(Entity item)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                ProvideDatabaseSet().Update(item);
            }
        }

        public void Delete(Entity item)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                ProvideDatabaseSet().Remove(item);
            }
        }
    }
}
