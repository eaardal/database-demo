using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DatabaseDemo.Contracts
{
    public interface ISearchableRepository
    {
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase;
        ICollection<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase;
    }
}
