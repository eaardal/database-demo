using System;

namespace UnitOfWorkImpl
{
    public interface ISessionProvider<out T>
    {
        ISessionAdapter<T> OpenSession();
    }
}