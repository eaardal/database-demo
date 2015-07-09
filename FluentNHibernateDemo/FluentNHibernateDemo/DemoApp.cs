using System;
using System.Linq;
using UnitOfWorkImpl;

namespace FluentNHibernateDemo
{
    class DemoApp
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DemoApp(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null) throw new ArgumentNullException("unitOfWorkFactory");

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Run()
        {
            try
            {
                using (var uow = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    var personRepository = uow.ResolveRepository<IPersonRepository>();

                    personRepository.InsertOrUpdate(new Person { Firstname = "John", Lastname = "Smith", Age = 20 });
                    personRepository.InsertOrUpdate(new Person { Firstname = "Jack", Lastname = "Lee", Age = 30 });
                    personRepository.InsertOrUpdate(new Person { Firstname = "Sarah", Lastname = "Kent", Age = 40 });

                    uow.Commit();
                }

                using (var uow = _unitOfWorkFactory.CreateUnitOfWork())
                {
                    var personRepository = uow.ResolveRepository<IPersonRepository>();
                    var emailRepository = uow.ResolveRepository<IEmailRepository>();

                    var jack = personRepository.GetAll().First(p => p.Firstname == "Jack");
                    personRepository.Delete(jack);

                    emailRepository.InsertOrUpdate(new Email { Sender = "jack@lee.com", Receiver = "sarah@kent.com", Subject = "hi", Body = "hello world" });

                    uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}