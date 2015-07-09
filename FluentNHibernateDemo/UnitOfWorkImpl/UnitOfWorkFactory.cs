using System;
using UnitOfWorkImpl.Infrastructure;

namespace UnitOfWorkImpl
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IIoC _ioc;
 
        public UnitOfWorkFactory(IIoC ioc)
        {
            if (ioc == null) throw new ArgumentNullException("ioc");
            _ioc = ioc;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return _ioc.Resolve<IUnitOfWork>();
        }
    }
}
