using System;
using System.Collections.Generic;

namespace DatabaseDemo.Contracts
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ICrudRepository CrudRepository;

        protected RepositoryBase(ICrudRepository crudRepository)
        {
            if (crudRepository == null) throw new ArgumentNullException("crudRepository");
            CrudRepository = crudRepository;
        }

        public TEntity GetById(int entityId)
        {
            return CrudRepository.GetById<TEntity>(entityId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return CrudRepository.GetAll<TEntity>();
        }

        public void Update(TEntity entity)
        {
            CrudRepository.Update(entity);
        }

        public void Insert(TEntity entity)
        {
            CrudRepository.Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            CrudRepository.Delete(entity);
        }

        public void InsertOrUpdate(TEntity entity)
        {
            CrudRepository.InsertOrUpdate(entity);
        }
    }
}
