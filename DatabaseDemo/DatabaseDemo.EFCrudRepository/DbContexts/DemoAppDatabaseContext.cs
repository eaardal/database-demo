using System.Data.Entity;
using DatabaseDemo.DomainModel;
using DatabaseDemo.EFCrudRepository.DbMappings;

namespace DatabaseDemo.EFCrudRepository.DbContexts
{
    public class DemoAppDatabaseContext : DbContext, IDemoAppDatabaseContext
    {
        public IDbSet<Person> People { get; set; }
        public IDbSet<City> Cities { get; set; }

        public DemoAppDatabaseContext(IDatabaseInitializer<DemoAppDatabaseContext> initializer)
            : base("default")
        {
            Database.SetInitializer(initializer);
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new CityMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
