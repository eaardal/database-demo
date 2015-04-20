using NHibernate;

namespace UnitOfWorkImpl
{
    public interface ISessionAdapterRegistrator<T>
    {
        ISessionAdapter<T> SetSession(T session);
    }
}