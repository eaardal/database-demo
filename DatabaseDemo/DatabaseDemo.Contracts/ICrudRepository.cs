namespace DatabaseDemo.Contracts
{
    public interface ICrudRepository : IReadOnlyRepository
    {
        void Update<TEntity>(TEntity entity) where TEntity : EntityBase;
        void Insert<TEntity>(TEntity entity) where TEntity : EntityBase;
        void Delete<TEntity>(TEntity entity) where TEntity : EntityBase;
        void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}
