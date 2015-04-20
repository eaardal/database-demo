using System;
using Microsoft.Practices.ServiceLocation;

namespace DatabaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database demo");

            Bootstrapper.Wire();

            var ioc = ServiceLocator.Current;

            var demo = ioc.GetInstance<IDemo>();
            demo.Run();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
