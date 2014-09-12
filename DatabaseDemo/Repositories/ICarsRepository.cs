using System.Collections.Generic;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.Repositories
{
    public interface ICarsRepository
    {
        List<Car> GetAllVolvos();
    }
}