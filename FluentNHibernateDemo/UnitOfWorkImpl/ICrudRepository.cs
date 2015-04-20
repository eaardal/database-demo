using System.Collections.Generic;

namespace UnitOfWorkImpl
{
    public interface ICrudRepository
    {
        IEnumerable<T> GetAll<T>();
        T GetById<T>(int id);
        void InsertOrUpdate<T>(T entity);
        void Delete<T>(T entity);
    }
}
