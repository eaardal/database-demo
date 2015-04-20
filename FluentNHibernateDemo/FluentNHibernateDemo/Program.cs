using System;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Util;
using UnitOfWorkImpl;

namespace FluentNHibernateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioc = Bootstrapper.Wire();

            DropCreateDatabase();

            var app = ioc.Resolve<DemoApp>();
            app.Run();
            
            Console.ReadLine();
        }

        private static void DropCreateDatabase()
        {
            var factory = SqlExpressSessionFactory.CreateFactory();
            var config = SqlExpressSessionFactory.Configuration;

            Console.WriteLine("Created configuration");

            using (var session = factory.OpenSession())
            {
                Console.WriteLine("Session is " + session.Connection.State);

                var exporter = new SchemaExport(config);
                exporter.Execute(true, true, false, session.Connection, Console.Out);

                Console.WriteLine("Done exporting");
            }
        }
    }
}
