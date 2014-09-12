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
            container.RegisterType<ICrudRepository, EntityFrameworkCrudRepository<PeopleContext>>();
            container.RegisterType<IPeopleContext, PeopleContext>();
            container.RegisterType<IDatabaseInitializer<PeopleContext>, NullDatabaseInitializer<PeopleContext>>();
        }
    }
}
