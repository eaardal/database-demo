using DatabaseDemo.Contracts;

namespace DatabaseDemo.DomainModel
{
    public class Car : EntityBase
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
