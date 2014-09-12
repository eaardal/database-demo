using DatabaseDemo.EFCrudRepository;
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

            // Let third party dependency libraries wire themselves up to avoid clutter up core bootstrapper and dependencies/references to thirdparty libraries
            EFCrudRepositoryBootstrapper.Wire(container);
            NHibernateCrudRepositoryBootstrapper.Wire(container);

            // Register core domain dependencies
            container.RegisterType<IPeopleRepository, PeopleRepository>();
            container.RegisterType<IDemo, Demo>();

            // Get rid of Unity dependencies. Use common ServiceLocator implementation which is supported by many IoC containers
            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
