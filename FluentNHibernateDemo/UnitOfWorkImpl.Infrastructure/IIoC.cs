using System.Collections.Generic;
using Autofac;

namespace UnitOfWorkImpl.Infrastructure
{
    public interface IIoC
    {
        void Register(IContainer container);
        T Resolve<T>();
        T Resolve<T>(params ConstructorParam[] constructorParams);
        IEnumerable<T> ResolveAll<T>();
    }
}