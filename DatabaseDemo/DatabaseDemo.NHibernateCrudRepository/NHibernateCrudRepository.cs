using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;
using NHibernate;
using NHibernate.Linq;

namespace DatabaseDemo.NHibernateCrudRepository
{
    public class NHibernateCrudRepository : ICrudRepository
    {
        private ISession _session;
        private ITransaction _transaction;

        public NHibernateCrudRepository()
        {
            _session = SqlExpressSessionFactory.CreateFactory().OpenSession();
            _transaction = _session.BeginTransaction();
        }

        public TEntity GetById<TEntity>(int entityId) where TEntity : EntityBase
        {
            return _session.Get<TEntity>(entityId);
        }

        public ICollection<TEntity> GetAll<TEntity>() where TEntity : EntityBase
        {
            return _session.Query<TEntity>().ToList();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _session.Update(entity);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _session.Save(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _session.Delete(entity);
        }

        public void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _session.SaveOrUpdate(entity);
        }
    }
}
