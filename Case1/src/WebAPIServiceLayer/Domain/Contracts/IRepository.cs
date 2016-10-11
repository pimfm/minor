using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebAPIServiceLayer.Domain.Contracts
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
        TEntity FindOneBy(Expression<Func<TEntity, bool>> filter);

        int Count();
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
