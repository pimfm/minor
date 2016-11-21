namespace WebAPIServiceLayer.Domain.Contracts
{
    public interface IFullRepository<TEntity, TKey> : IRepository<TEntity>
    {
        TEntity Find(TKey key);
    }
}