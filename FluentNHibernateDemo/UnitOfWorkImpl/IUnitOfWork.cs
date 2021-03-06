using System;

namespace UnitOfWorkImpl
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        TService ResolveRepository<TService>();
    }
}