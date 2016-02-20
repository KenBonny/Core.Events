using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Autofac;
using Kenbo.Core.Events.Contracts;
using Shouldly;
using Xunit;

namespace Kenbo.Core.Events.Tests
{
    public class When_raising_events : TestBase
    {
        private readonly ICollection<EventArgs> _arguments = new Collection<EventArgs>(); 

        public When_raising_events()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new GenericEventHandler<TestWith>(x => _arguments.Add(x)))
                   .As<IEventHandler<TestWith>>();
            builder.RegisterInstance(new GenericEventHandler<TestWith>(x => _arguments.Add(x)))
                   .As<IEventHandler<TestWith>>();
            builder.RegisterInstance(new GenericEventHandler<NeverCalled>(x => _arguments.Add(x)))
                   .As<IEventHandler<NeverCalled>>();

            Event.Register<TestWith>(x => _arguments.Add(x));
            Event.Register<NeverCalled>(x => _arguments.Add(x));
            Event.Container = new IocContainer(builder.Build());
        }

        [Fact]
        public void All_handlers_should_be_called()
        {
            Event.Raise(TestWith.Create("Test with this"));
            _arguments.Count.ShouldBe(3, Message());
        }

        [Fact]
        public void Clearing_callbacks_should_not_be_called_anymore()
        {
            Event.ClearCallbacks();
            Event.Raise(TestWith.Create("Test with this"));
            _arguments.Count.ShouldBe(2, Message());
        }
    }
}
