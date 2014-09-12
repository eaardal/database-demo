using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseDemo.Contracts
{
    public interface IAsyncSearchableRepository
    {
        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase;

        Task<ICollection<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> match)
            where TEntity : EntityBase;
    }
}
