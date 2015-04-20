using System.Collections.Generic;
using System.Linq;
using DatabaseDemo.Contracts;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public class PeopleRepository : RepositoryBase<Person>, IPeopleRepository
    {
        public PeopleRepository(ICrudRepository crudRepository) : base(crudRepository)
        {
        }

        public List<Person> GetPeopleOver30YearsOld()
        {
            return CrudRepository.GetAll<Person>().Where(p => p.Age > 30).ToList();
        } 
    }
}
