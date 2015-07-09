using System;

namespace UnitOfWorkImpl
{
    public interface ISessionAdapter<out T> : IDisposable
    {
        T CurrentSession { get; }
    }
}