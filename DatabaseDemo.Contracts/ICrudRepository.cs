namespace DatabaseDemo.Contracts
{
    public interface ICrudRepository : IReadOnlyRepository
    {
        int Update<TEntity>(TEntity entity) where TEntity : EntityBase;
        int Insert<TEntity>(TEntity entity) where TEntity : EntityBase;
        int Delete<TEntity>(TEntity entity) where TEntity : EntityBase;
        int InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}
