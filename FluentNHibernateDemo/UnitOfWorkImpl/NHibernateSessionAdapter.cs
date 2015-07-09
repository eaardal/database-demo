using System;
using NHibernate;

namespace UnitOfWorkImpl
{
    public class NHibernateSessionAdapter : ISessionAdapter<ISession> //, ISessionAdapterRegistrator<ISession>
    {
        public ISession CurrentSession { get; private set; }

        public NHibernateSessionAdapter(ISession session)
        {
            if (session == null) throw new ArgumentNullException("session");
            CurrentSession = session;
        }

        //public ISessionAdapter<ISession> SetSession(ISession session)
        //{
        //    CurrentSession = session;
        //    return this;
        //}

        public void Dispose()
        {
            CurrentSession.Dispose();
        }
    }
}