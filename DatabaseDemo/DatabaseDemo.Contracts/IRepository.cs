using System.Collections.Generic;

namespace DatabaseDemo.Contracts
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Update(TEntity entity);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void InsertOrUpdate(TEntity entity);
    }
}
