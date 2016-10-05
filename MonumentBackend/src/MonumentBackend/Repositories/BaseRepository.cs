using MonumentBackend.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MonumentBackend.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : IDisposable, new()
    {
        private ContextFactory<TContext> _factory = new ContextFactory<TContext>();

        public abstract DbSet<TEntity> ProvideDatabaseSet();

        public virtual IEnumerable<TEntity> FindAll()
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return ProvideDatabaseSet().ToList();
            }
        }
        
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return ProvideDatabaseSet().Where(filter).ToList();
            }
        }

        public virtual int Count()
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return ProvideDatabaseSet().Count();
            }
        }

        public virtual void Insert(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                ProvideDatabaseSet().Add(item);
            }
        }

        public virtual void Update(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                ProvideDatabaseSet().Update(item);
            }
        }

        public virtual void Delete(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                ProvideDatabaseSet().Remove(item);
            }
        }
    }
}
