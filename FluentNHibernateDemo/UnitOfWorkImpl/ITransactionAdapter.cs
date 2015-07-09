using System;

namespace UnitOfWorkImpl
{
    public interface ITransactionAdapter : IDisposable
    {
        void Rollback();
        void Commit();
        bool IsActive { get; }
    }
}