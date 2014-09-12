using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseDemo.Contracts
{
    public interface IAsyncReadOnlyRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(int entityId) where TEntity : EntityBase;
        Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : EntityBase;
    }
}
