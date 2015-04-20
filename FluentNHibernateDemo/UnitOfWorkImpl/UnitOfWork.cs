using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkImpl
{
    public class UnitOfWork<T> : IUnitOfWork
    {
        private readonly ITransactionProvider<T> _transactionProvider;
        private readonly ISessionProvider<T> _sessionProvider;

        private ISessionAdapter<T> _currentSession;
        private ITransactionAdapter _currentTransaction;

        public UnitOfWork(ITransactionProvider<T> transactionProvider, ISessionProvider<T> sessionProvider)
        {
            _transactionProvider = transactionProvider;
            _sessionProvider = sessionProvider;
        }

        public void Commit()
        {
            _currentTransaction.Commit();
        }

        public void Rollback()
        {
            _currentTransaction.Rollback();
        }

        public void Dispose()
        {
            if (_currentTransaction.IsActive)
            {
                _currentTransaction.Rollback();
            }

            _currentSession = null;
            _currentTransaction = null;
        }

        public IUnitOfWork StartTransaction()
        {
            _currentSession = _sessionProvider.OpenSession();
            _currentTransaction = _transactionProvider.BeginTransaction(_currentSession);

            return this;
        }
    }
}
