using System.Threading.Tasks;

namespace DatabaseDemo.Contracts
{
    public interface IComplexRepository : ICrudRepository, IAsyncCrudRepository, ISearchableRepository, IAsyncSearchableRepository
    {
        int Count<TEntity>() where TEntity : EntityBase;

        Task<int> CountAsync<TEntity>() where TEntity : EntityBase;
    }
}
