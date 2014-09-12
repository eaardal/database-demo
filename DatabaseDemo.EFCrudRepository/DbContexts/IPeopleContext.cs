using System.Data.Entity;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.EFCrudRepository.DbContexts
{
    public interface IPeopleContext
    {
        IDbSet<Person> People { get; set; }
    }
}