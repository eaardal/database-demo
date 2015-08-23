using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(ICrudRepository crudRepository) : base(crudRepository)
        {

        }
    }
}
