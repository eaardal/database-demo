namespace UnitOfWorkImpl
{
    public interface ISessionAdapter<out T>
    {
        T CurrentSession { get; }
    }
}