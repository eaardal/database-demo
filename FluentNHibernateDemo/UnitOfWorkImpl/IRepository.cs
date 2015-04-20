using System.Collections.Generic;

namespace UnitOfWorkImpl
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void InsertOrUpdate(T entity);
        void Delete(T entity);
    }
}