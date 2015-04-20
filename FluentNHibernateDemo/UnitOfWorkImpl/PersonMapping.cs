using FluentNHibernate.Mapping;

namespace UnitOfWorkImpl
{
    class PersonMapping : ClassMap<Person>
    {
        public PersonMapping()
        {
            Table("PERSON");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Firstname).Column("FIRSTNAME").Not.Nullable();
            Map(x => x.Lastname).Column("LASTNAME").Not.Nullable();
            Map(x => x.Age).Column("AGE").Not.Nullable();
        }
    }
}