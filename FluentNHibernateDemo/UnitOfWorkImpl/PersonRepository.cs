using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkImpl
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ICrudRepository crudRepository) : base(crudRepository)
        {
        }
    }
}
