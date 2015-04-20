using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;
using NHibernate;
using NHibernate.Linq;

namespace DatabaseDemo.NHibernateCrudRepository
{
    public class NHibernateCompleteRepository : IComplexRepository
    {
        private ISession _session;
        private ITransaction _transaction;

        public NHibernateCompleteRepository()
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

        public async Task<TEntity> GetByIdAsync<TEntity>(int entityId) where TEntity : EntityBase
        {
            return await Task.Run(() => _session.Get<TEntity>(entityId));
        }

        public async Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : EntityBase
        {
            return await Task.Run(() => _session.Query<TEntity>().ToList());
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task InsertOrUpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public int Count<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync<TEntity>() where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }
    }
}
