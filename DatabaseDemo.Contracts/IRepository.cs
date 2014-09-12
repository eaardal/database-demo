using System.Collections.Generic;

namespace DatabaseDemo.Contracts
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        int Update(TEntity entity);

        int Insert(TEntity entity);

        int Delete(TEntity entity);

        int InsertOrUpdate(TEntity entity);
    }
}
