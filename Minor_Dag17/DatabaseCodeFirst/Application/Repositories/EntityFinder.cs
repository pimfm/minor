namespace DatabaseCodeFirst.Application.Repositories
{
    public interface EntityFinder<TEntity, TKey>
    {
        TEntity Find(TKey key);
    }
}