using System.Data.Entity;
using DatabaseDemo.Contracts;
using DatabaseDemo.EFCrudRepository.DbContexts;
using Microsoft.Practices.Unity;

namespace DatabaseDemo.EFCrudRepository
{
    public static class EFCrudRepositoryBootstrapper
    {
        public static void Wire(IUnityContainer container)
        {
            container.RegisterType<IPeopleContext, PeopleContext>();
            container.RegisterType<ICrudRepository, EntityFrameworkCrudRepository<PeopleContext>>();
            
            // For use when running the database normally (no initialization logic)
            container.RegisterType<IDatabaseInitializer<PeopleContext>, NullDatabaseInitializer<PeopleContext>>();

            // For use when re-creating the database e.x with a drop-create script/console app (this would then be in another Bootstrapper for that script/app)
            //container.RegisterType<IDatabaseInitializer<PeopleContext>, DropCreatePeopleDbInitializer>();
        }
    }
}
