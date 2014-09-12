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

        public int Update(TEntity entity)
        {
            return CrudRepository.Update(entity);
        }

        public int Insert(TEntity entity)
        {
            return CrudRepository.Insert(entity);
        }

        public int Delete(TEntity entity)
        {
            return CrudRepository.Delete(entity);
        }

        public int InsertOrUpdate(TEntity entity)
        {
            return CrudRepository.InsertOrUpdate(entity);
        }
    }
}
