using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Infrastructure.Factories;

namespace WebAPIServiceLayer.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, IDisposable
    {
        private IManufacturesContext<TContext> _factory;

        public BaseRepository(IManufacturesContext<TContext> factory)
        {
            _factory = factory;
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity FindOneBy(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual int Count()
        {
            using (TContext context = _factory.ManufactureContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public virtual void Insert(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                context.Set<TEntity>().Add(item);
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                context.Set<TEntity>().Update(item);
                context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity item)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                context.Set<TEntity>().Remove(item);
                context.SaveChanges();
            }
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            using (TContext context = _factory.ManufactureContext())
            {
                context.Set<TEntity>().AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
