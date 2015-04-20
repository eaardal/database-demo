using NHibernate;

namespace UnitOfWorkImpl
{
    public class NHibernateTransactionProvider : ITransactionProvider<ISession>
    {
        public ITransactionAdapter BeginTransaction(ISessionAdapter<ISession> session)
        {
            var transaction = session.CurrentSession.BeginTransaction();
            return new NHibernateTransactionAdapter(transaction);
        }
    }
}