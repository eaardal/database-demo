using DatabaseDemo.EFCrudRepository;
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
            EFCrudRepositoryBootstrapper.Wire(container);

            container.RegisterType<IPeopleRepository, PeopleRepository>();

            var unityServiceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
