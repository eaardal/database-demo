using System.Data.Entity;
using DatabaseDemo.Contracts;
using DatabaseDemo.EFCrudRepository;
using DatabaseDemo.EFCrudRepository.DbContexts;
using DatabaseDemo.EFCrudRepository.DbInitializers;
using DatabaseDemo.NHibernateCrudRepository;
using DatabaseDemo.Repositories;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DatabaseDemo
{
    public static class Bootstrapper
    {
        public static void Wire()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDemoAppDatabaseContext, DemoAppDatabaseContext>();
            container.RegisterType<ICrudRepository, EntityFrameworkCrudRepository<DemoAppDatabaseContext>>();

            container.RegisterType<IDatabaseInitializer<DemoAppDatabaseContext>, NullDatabaseInitializer<DemoAppDatabaseContext>>();
            //container.RegisterType<IDatabaseInitializer<DemoAppDatabaseContext>, DropCreateDatabaseInitializer>();

            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<IPeopleRepository, PeopleRepository>();
            container.RegisterType<IDemo, Demo>();

            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
