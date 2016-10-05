namespace MonumentBackend.Repositories
{
    public interface IEntityRepository<TEntity, TKey> : IRepository<TEntity>
    {
        TEntity Find(TKey key);
    }
}