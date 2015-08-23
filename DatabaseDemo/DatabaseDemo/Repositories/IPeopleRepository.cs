using System.Collections.Generic;
using DatabaseDemo.Contracts;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public interface IPeopleRepository : IRepository<Person>
    {
        List<Person> GetPeopleOver30YearsOld();
    }
}