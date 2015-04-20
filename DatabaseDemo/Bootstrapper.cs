using System.Data.Entity;
using DatabaseDemo.Contracts;
using DatabaseDemo.EFCrudRepository;
using DatabaseDemo.EFCrudRepository.DbContexts;
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

            container.RegisterType<IPeopleContext, PeopleContext>();
            container.RegisterType<ICrudRepository, EntityFrameworkCrudRepository<PeopleContext>>();

            container.RegisterType<IDatabaseInitializer<PeopleContext>, NullDatabaseInitializer<PeopleContext>>();

            container.RegisterType<IPeopleRepository, PeopleRepository>();
            container.RegisterType<IDemo, Demo>();

            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
