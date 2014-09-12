using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;

namespace DatabaseDemo.NHibernateCrudRepository
{
    public class NHibernateCrudRepository : ICrudRepository
    {
        public TEntity GetById<TEntity>(int entityId) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetAll<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public int Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }
    }
}
