using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autofac;
using Kenbo.Core.Events.Contracts;
using Shouldly;
using Xunit;

namespace Kenbo.Core.Events.Tests
{
    public class When_raising_an_event
    {
        private readonly ICollection<EventArgs> _arguments = new Collection<EventArgs>(); 

        public When_raising_an_event()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new GenericEventHandler<TestEvent>(x => _arguments.Add(x)))
                   .As<IEventHandler<TestEvent>>();
            builder.RegisterInstance(new GenericEventHandler<TestEvent>(x => _arguments.Add(x)))
                   .As<IEventHandler<TestEvent>>();
            builder.RegisterInstance(new GenericEventHandler<NeverCalledEvent>(x => _arguments.Add(x)))
                   .As<IEventHandler<NeverCalledEvent>>();

            Event.Register<TestEvent>(x => _arguments.Add(x));
            Event.Register<NeverCalledEvent>(x => _arguments.Add(x));
            Event.Container = new IocContainer(builder.Build());
        }

        [Fact]
        public void All_handlers_should_be_called()
        {
            Event.Raise(TestEvent.Create("Test this stuff"));
            _arguments.Count.ShouldBe(3);
        }
    }
}
