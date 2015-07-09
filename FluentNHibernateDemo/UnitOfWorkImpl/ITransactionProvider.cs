using System;

namespace UnitOfWorkImpl
{
    public interface ITransactionProvider<in T>
    {
        ITransactionAdapter BeginTransaction(ISessionAdapter<T> session);
    }
}