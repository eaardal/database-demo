using System;
using DatabaseDemo.Repositories;

namespace DatabaseDemo
{
    class Demo : IDemo
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICarsRepository _carsRepository;

        public Demo(IPeopleRepository peopleRepository, ICarsRepository carsRepository)
        {
            if (peopleRepository == null) throw new ArgumentNullException("peopleRepository");
            if (carsRepository == null) throw new ArgumentNullException("carsRepository");

            _peopleRepository = peopleRepository;
            _carsRepository = carsRepository;
        }

        public void Run()
        {
            _peopleRepository.GetPeopleOver30YearsOld().ForEach(p => Console.WriteLine(p.FirstName + " " + p.LastName + " is over 30 years old"));
            _carsRepository.GetAllVolvos().ForEach(car => Console.WriteLine(car.Make + " " + car.Model + " " + " made in " + car.Year));
        }
    }
}