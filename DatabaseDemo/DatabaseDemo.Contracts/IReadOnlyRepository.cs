using System.Collections.Generic;

namespace DatabaseDemo.Contracts
{
    public interface IReadOnlyRepository
    {
        TEntity GetById<TEntity>(int entityId) where TEntity : EntityBase;
        ICollection<TEntity> GetAll<TEntity>() where TEntity : EntityBase;
    }
}
