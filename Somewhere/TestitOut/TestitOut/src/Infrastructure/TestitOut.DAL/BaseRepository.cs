using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestitOut.Services;

namespace TestitOut.DAL
{
    public abstract class BaseRepository<Entity, Key, Context> 
        : IRepository<Entity, Key>, 
        IDisposable 
        where Context : DbContext 
        where Entity : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        protected abstract DbSet<Entity> GetDbSet();
        protected abstract Key GetKeyFrom(Entity item);

        public virtual IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter)
        {
            return GetDbSet().Where(filter);
        }

        public virtual Entity Find(Key id)
        {
            return GetDbSet().SingleOrDefault(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IEnumerable<Entity> FindAll()
        {
            return GetDbSet();
        }

        public virtual int Insert(Entity item)
        {
            _context.Add(item);
            return _context.SaveChanges();
        }

        public virtual int InsertRange(IEnumerable<Entity> items)
        {
            _context.AddRange(items);
            return _context.SaveChanges();
        }

        public virtual int Update(Entity item)
        {
            _context.Update(item);
            return _context.SaveChanges();
        }

        public virtual int UpdateRange(IEnumerable<Entity> items)
        {
            _context.UpdateRange(items);
            return _context.SaveChanges();
        }

        public virtual int Delete(Key id)
        {
            var toRemove = Find(id);
            _context.Remove(toRemove);
            return _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}