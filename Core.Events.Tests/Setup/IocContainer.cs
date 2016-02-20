using System;
using System.Collections.Generic;
using Autofac;
using Kenbo.Core.Events.Contracts;

namespace Kenbo.Core.Events.Tests
{
    public class IocContainer : IIocContainer
    {
        private readonly IContainer _container;

        public IocContainer(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<IEventHandler<T>> ResolveAll<T>() where T : EventArgs
        {
            var handlers = _container.Resolve<IEnumerable<IEventHandler<T>>>();
            return handlers;
        }
    }
}