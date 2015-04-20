using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDemo.DomainModel;
using FluentNHibernate.Mapping;

namespace DatabaseDemo.NHibernateCrudRepository.DbMappings
{
    public class PersonMapping : ClassMap<Person>
    {
        public PersonMapping()
        {
            Table("People");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.Age).Column("Age");
        }
    }
}
