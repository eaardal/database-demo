namespace DatabaseDemo.Contracts
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public EntityState State { get; set; }
    }
}
