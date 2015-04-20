using System;
using NHibernate;

namespace UnitOfWorkImpl
{
    public class NHibernateSessionAdapter : ISessionAdapter<ISession>, ISessionAdapterRegistrator<ISession>
    {
        public ISession CurrentSession { get; private set; }

        public ISessionAdapter<ISession> SetSession(ISession session)
        {
            CurrentSession = session;
            return this;
        }
    }
}