using System;
using System.Collections.Generic;
using Autofac;

namespace FluentNHibernateDemo
{
    class IoC : IIoC
    {
        private IContainer _container;

        public void Register(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }
    }
}