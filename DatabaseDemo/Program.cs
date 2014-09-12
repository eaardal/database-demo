using System;
using DatabaseDemo.EFCrudRepository;
using DatabaseDemo.Repositories;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DatabaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database demo");

            Bootstrapper.Wire();

            var ioc = ServiceLocator.Current;

            var repo = ioc.GetInstance<IPeopleRepository>();

            repo.GetPeopleOver30YearsOld().ForEach(p => Console.WriteLine(p.FirstName + " " + p.LastName + " is over 30 years old"));
            
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
