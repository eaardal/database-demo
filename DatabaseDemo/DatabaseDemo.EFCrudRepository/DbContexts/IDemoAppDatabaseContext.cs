using System.Data.Entity;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.EFCrudRepository.DbContexts
{
    public interface IDemoAppDatabaseContext
    {
        IDbSet<Person> People { get; set; }
    }
}