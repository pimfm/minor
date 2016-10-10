using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BackendService.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
        TEntity FindOneBy(Expression<Func<TEntity, bool>> filter);

        int Count();
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
