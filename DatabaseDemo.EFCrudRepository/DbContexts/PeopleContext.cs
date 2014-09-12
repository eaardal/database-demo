using System.Data.Entity;
using DatabaseDemo.DomainModel;
using DatabaseDemo.EFCrudRepository.DbMappings;

namespace DatabaseDemo.EFCrudRepository.DbContexts
{
    public class PeopleContext : DbContext, IPeopleContext
    {
        public IDbSet<Person> People { get; set; }

        public PeopleContext(IDatabaseInitializer<PeopleContext> initializer)
            : base("eaardal-db-connectionstring")
        {
            Database.SetInitializer(initializer);
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
