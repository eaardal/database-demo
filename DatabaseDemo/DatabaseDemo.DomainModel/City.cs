using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.Contracts;

namespace DatabaseDemo.DomainModel
{
    public class City : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Person> Citizens { get; set; }
    }
}
