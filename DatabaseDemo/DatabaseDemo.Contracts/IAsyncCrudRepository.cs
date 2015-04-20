using System.Threading.Tasks;

namespace DatabaseDemo.Contracts
{
    public interface IAsyncCrudRepository : IAsyncReadOnlyRepository
    {
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task InsertOrUpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}
