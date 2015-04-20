using System;
using System.Collections.Generic;

namespace UnitOfWorkImpl
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected readonly ICrudRepository CrudRepository;

        protected RepositoryBase(ICrudRepository crudRepository)
        {
            if (crudRepository == null) throw new ArgumentNullException("crudRepository");
            CrudRepository = crudRepository;
        }

        public IEnumerable<T> GetAll()
        {
            return CrudRepository.GetAll<T>();
        }

        public T GetById(int id)
        {
            return CrudRepository.GetById<T>(id);
        }

        public void InsertOrUpdate(T entity)
        {
            CrudRepository.InsertOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            CrudRepository.Delete(entity);
        }
    }
}