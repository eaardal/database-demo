using System;
using System.Linq;
using UnitOfWorkImpl;

namespace FluentNHibernateDemo
{
    class DemoApp
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IEmailRepository _emailRepository;

        public DemoApp(IUnitOfWork unitOfWork, IPersonRepository personRepository, IEmailRepository emailRepository)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            if (personRepository == null) throw new ArgumentNullException("personRepository");
            if (emailRepository == null) throw new ArgumentNullException("emailRepository");

            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _emailRepository = emailRepository;
        }

        public void Run()
        {
            try
            {
                using (var transaction = _unitOfWork.StartTransaction())
                {
                    _personRepository.InsertOrUpdate(new Person { Firstname = "John", Lastname = "Smith", Age = 20 });
                    _personRepository.InsertOrUpdate(new Person { Firstname = "Jack", Lastname = "Lee", Age = 30 });
                    _personRepository.InsertOrUpdate(new Person { Firstname = "Sarah", Lastname = "Kent", Age = 40 });

                    transaction.Commit();
                }

                using (var transaction = _unitOfWork.StartTransaction())
                {
                    var jack = _personRepository.GetAll().First(p => p.Firstname == "Jack");
                    _personRepository.Delete(jack);

                    _emailRepository.InsertOrUpdate(new Email { Sender = "jack@lee.com", Receiver = "sarah@kent.com", Subject = "hi", Body = "hello world" });

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}