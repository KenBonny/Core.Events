using System;
using Kenbo.Core.Events.Contracts;

namespace Kenbo.Core.Events.Tests
{
    public class GenericEventHandler<T> : IEventHandler<T>
        where T : EventArgs
    {
        private readonly Action<T> _callback;

        public GenericEventHandler(Action<T> callback)
        {
            _callback = callback;
        }

        public void Handle(T argument)
        {
            _callback(argument);
        }
    }
}