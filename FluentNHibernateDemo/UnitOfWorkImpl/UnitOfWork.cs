using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UnitOfWorkImpl.Infrastructure;

namespace UnitOfWorkImpl
{
    public class UnitOfWork<T> : IUnitOfWork where T : class
    {
        private readonly IIoC _ioc;
        
        private ISessionAdapter<T> _currentSession;
        private ITransactionAdapter _currentTransaction;

        public UnitOfWork(ITransactionProvider<T> transactionProvider, ISessionProvider<T> sessionProvider, IIoC ioc)
        {
            if (transactionProvider == null) throw new ArgumentNullException("transactionProvider");
            if (sessionProvider == null) throw new ArgumentNullException("sessionProvider");
            if (ioc == null) throw new ArgumentNullException("ioc");

            _ioc = ioc;

            _currentSession = sessionProvider.OpenSession();
            _currentTransaction = transactionProvider.BeginTransaction(_currentSession);
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
            
            _currentSession.Dispose();
            _currentTransaction.Dispose();

            _currentSession = null;
            _currentTransaction = null;
        }

        public TRepo ResolveRepository<TRepo>()
        {
            try
            {
                var sessionInjectableRespository = _ioc.Resolve<ISessionInjectable>(new ConstructorParam(_currentSession));
                var crudRepository = sessionInjectableRespository as ICrudRepository;

                if (crudRepository != null)
                {
                    return _ioc.Resolve<TRepo>(new ConstructorParam(crudRepository));
                }
                throw new UnitOfWorkException("Expected the " + typeof(ISessionInjectable).FullName +
                                              " implementor to be a " + typeof(ICrudRepository).FullName + " repository");
            }
            catch (Exception ex)
            {
                throw new UnitOfWorkException("Unit of Work could not resolve " + typeof(TRepo).FullName, ex);
            }
        }
    }
}
