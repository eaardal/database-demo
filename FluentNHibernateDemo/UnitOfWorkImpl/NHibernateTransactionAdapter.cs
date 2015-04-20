using NHibernate;

namespace UnitOfWorkImpl
{
    public class NHibernateTransactionAdapter : ITransactionAdapter
    {
        private readonly ITransaction _transaction;

        public NHibernateTransactionAdapter(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public bool IsActive => _transaction.IsActive;
    }
}