using System.Threading.Tasks;

namespace DatabaseDemo.Contracts
{
    public interface IAsyncCrudRepository : IAsyncReadOnlyRepository
    {
        Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
        Task<int> InsertOrUpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
    }
}
