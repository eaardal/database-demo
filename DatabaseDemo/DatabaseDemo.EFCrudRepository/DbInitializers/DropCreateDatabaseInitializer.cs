using System.Collections.Generic;
using System.Data.Entity;
using DatabaseDemo.DomainModel;
using DatabaseDemo.EFCrudRepository.DbContexts;

namespace DatabaseDemo.EFCrudRepository.DbInitializers
{
    public class DropCreateDatabaseInitializer : DropCreateDatabaseAlways<DemoAppDatabaseContext>
    {
        protected override void Seed(DemoAppDatabaseContext context)
        {
            var john = new Person { FirstName = "John", LastName = "Smith", Age = 35 };
            var jack = new Person { FirstName = "Jack", LastName = "Jones", Age = 76 };
            var jane = new Person { FirstName = "Jane", LastName = "Doe", Age = 15 };
            var sarah = new Person { FirstName = "Sarah", LastName = "Kelly", Age = 14 };

            var newYork = new City { Name = "New York", Citizens = new List<Person> { john, jane } };
            var seattle = new City { Name = "Seattle", Citizens = new List<Person> { jack, sarah } };

            context.People.Add(john);
            context.People.Add(jack);
            context.People.Add(jane);
            context.People.Add(sarah);

            context.Cities.Add(newYork);
            context.Cities.Add(seattle);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
