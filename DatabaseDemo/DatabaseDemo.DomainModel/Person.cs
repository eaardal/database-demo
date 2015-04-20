using DatabaseDemo.Contracts;

namespace DatabaseDemo.DomainModel
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
