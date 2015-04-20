using System.Collections.Generic;
using Autofac;

namespace FluentNHibernateDemo
{
    internal interface IIoC
    {
        void Register(IContainer container);
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}