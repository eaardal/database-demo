using System.Collections.Generic;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public interface IPeopleRepository
    {
        List<Person> GetPeopleOver30YearsOld();
    }
}