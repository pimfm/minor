using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bagagedrager.Frontend.Webshop.Services
{
    public interface IRepository<TEntity, TKey> 
        : IDisposable
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        TEntity Find(TKey id);

        int Insert(TEntity item);

        int InsertRange(IEnumerable<TEntity> items);

        int Update(TEntity item);

        int UpdateRange(IEnumerable<TEntity> items);

        int Delete(TKey item);
    }
}
