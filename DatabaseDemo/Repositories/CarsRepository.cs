using System.Collections.Generic;
using System.Linq;
using DatabaseDemo.Contracts;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public class CarsRepository : RepositoryBase<Car>, ICarsRepository
    {
        public CarsRepository(ICrudRepository crudRepository) : base(crudRepository)
        {
        }

        public List<Car> GetAllVolvos()
        {
            return CrudRepository.GetAll<Car>().Where(car => car.Make == "Volvo").ToList();
        }
    }
}
