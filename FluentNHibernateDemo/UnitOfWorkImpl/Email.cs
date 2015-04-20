namespace UnitOfWorkImpl
{
    public class Email
    {
        public virtual int Id { get; set; }
        public virtual string Sender { get; set; }
        public virtual string Receiver { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
    }
}