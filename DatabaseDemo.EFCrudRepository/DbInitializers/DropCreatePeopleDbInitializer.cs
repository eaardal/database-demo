using System.Data.Entity;
using DatabaseDemo.DomainModel;
using DatabaseDemo.EFCrudRepository.DbContexts;

namespace DatabaseDemo.EFCrudRepository.DbInitializers
{
    public class DropCreatePeopleDbInitializer : DropCreateDatabaseAlways<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            context.People.Add(new Person { FirstName = "John", LastName = "Smith", Age = 35 });
            context.People.Add(new Person { FirstName = "Jane", LastName = "Doe", Age = 15 });

            base.Seed(context);
        }
    }
}
