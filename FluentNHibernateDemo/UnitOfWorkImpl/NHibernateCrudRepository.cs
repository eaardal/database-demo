using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace UnitOfWorkImpl
{
    public class NHibernateCrudRepository : ICrudRepository, ISessionInjectable
    {
        private readonly ISessionAdapter<ISession> _session;

        public NHibernateCrudRepository(ISessionAdapter<ISession> session)
        {
            if (session == null) throw new ArgumentNullException("session");
            _session = session;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _session.CurrentSession.Query<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            return _session.CurrentSession.Get<T>(id);
        }

        public void InsertOrUpdate<T>(T entity)
        {
            _session.CurrentSession.SaveOrUpdate(entity);
        }

        public void Delete<T>(T entity)
        {
            _session.CurrentSession.Delete(entity);
        }

        public ISessionAdapter<ISession> Session { get { return _session; } }
    }
}