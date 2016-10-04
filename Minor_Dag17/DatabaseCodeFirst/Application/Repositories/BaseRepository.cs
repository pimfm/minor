using DatabaseCodeFirst.Application.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseCodeFirst.Application.Repositories
{
    public abstract class BaseRepository<TEntity, TFactory, TContext> : IRepository<TEntity>
        where TEntity : class
        where TFactory : ManufacturesContext<TContext>
        where TContext : IDisposable
    {
        private TFactory _factory;

        public BaseRepository(TFactory factory)
        {
            _factory = factory;
        }

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
