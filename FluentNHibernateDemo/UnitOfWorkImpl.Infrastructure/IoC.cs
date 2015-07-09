using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Features.GeneratedFactories;

namespace UnitOfWorkImpl.Infrastructure
{
    public class IoC : IIoC
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

        public T Resolve<T>(params ConstructorParam[] constructorParams)
        {
            var typedParams = constructorParams.Select(p => new TypedParameter(p.Param.GetType(), p.Param));

            return _container.Resolve<T>(typedParams);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }
    }

    public class ConstructorParam
    {
        public object Param { get; set; }

        public ConstructorParam(object param)
        {
            Param = param;
        }
    }

    //public class ConstructorParam<T>
    //{
    //    public T Param { get; set; }

    //    public ConstructorParam(T param)
    //    {
    //        Param = param;
    //    }
    //}
}