using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkImpl
{
    public class EmailRepository : RepositoryBase<Email>, IEmailRepository
    {
        public EmailRepository(ICrudRepository crudRepository) : base(crudRepository)
        {
        }
    }
}
