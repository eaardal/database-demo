using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NHibernate;
using UnitOfWorkImpl;
using UnitOfWorkImpl.Infrastructure;

namespace FluentNHibernateDemo
{
    class Bootstrapper
    {
        public static IIoC Wire()
        {
            var builder = new ContainerBuilder();

            var executingAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = executingAssembly.GetReferencedAssemblies();
            var appAssemblies =
                referencedAssemblies.Where(a => a.Name.Equals("UnitOfWorkImpl"))
                    .Select(Assembly.Load)
                    .Concat(new[] {executingAssembly})
                    .ToArray();

            builder.RegisterAssemblyTypes(appAssemblies)
                .Except<IoC>()
                .Except<NHibernateTransactionProvider>()
                .Except<NHibernateSessionProvider>()
                .Except<NHibernateSessionAdapter>()
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterType<IoC>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<UnitOfWork<ISession>>().As<IUnitOfWork>();
            builder.RegisterType<NHibernateTransactionProvider>().As<ITransactionProvider<ISession>>();
            builder.RegisterType<NHibernateSessionProvider>().As<ISessionProvider<ISession>>();
            builder.RegisterType<NHibernateSessionAdapter>().As<ISessionAdapter<ISession>>(); //.As<ISessionAdapterRegistrator<ISession>>();
            
            var container = builder.Build();

            var ioc = container.Resolve<IIoC>();
            ioc.Register(container);

            return ioc;
        }
    }
}
