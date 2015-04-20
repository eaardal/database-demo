namespace UnitOfWorkImpl
{
    public interface ITransactionAdapter
    {
        void Rollback();
        void Commit();
        bool IsActive { get; }
    }
}