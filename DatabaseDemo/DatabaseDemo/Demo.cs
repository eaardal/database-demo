using System;
using System.Linq;
using DatabaseDemo.DomainModel;
using DatabaseDemo.Repositories;

namespace DatabaseDemo
{
    class Demo : IDemo
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ICityRepository _cityRepository;

        public Demo(IPeopleRepository peopleRepository, ICityRepository cityRepository)
        {
            if (peopleRepository == null) throw new ArgumentNullException(nameof(peopleRepository));
            if (cityRepository == null) throw new ArgumentNullException(nameof(cityRepository));

            _peopleRepository = peopleRepository;
            _cityRepository = cityRepository;
        }

        public void Run()
        {
            var bill = new Person { FirstName = "Bill", LastName = "Smith", Age = 34 };
            var seattle = _cityRepository.GetAll().Single(c => c.Name == "Seattle");
            seattle.Citizens.Add(bill);

            _cityRepository.InsertOrUpdate(seattle);

            PrintCitizens();
        }

        private void PrintCitizens()
        {
            var cities = _cityRepository.GetAll();

            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Name} has {city.Citizens.Count} citizens:");

                foreach (var citizen in city.Citizens)
                {
                    Console.WriteLine($"> {citizen.FirstName} {citizen.LastName} ({citizen.Age}y/o)");
                }
            }
        }
    }
}