using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace UnitOfWorkImpl
{
    public class NHibernateSessionProvider : ISessionProvider<ISession>
    {
        private readonly ISessionAdapterRegistrator<ISession> _sessionRegistrator;

        public NHibernateSessionProvider(ISessionAdapterRegistrator<ISession> sessionRegistrator)
        {
            if (sessionRegistrator == null) throw new ArgumentNullException("sessionRegistrator");
            _sessionRegistrator = sessionRegistrator;
        }

        public ISessionAdapter<ISession> OpenSession()
        {
            var factory = SqlExpressSessionFactory.CreateFactory();
            var session = factory.OpenSession();
            return _sessionRegistrator.SetSession(session);
        }
    }
}
