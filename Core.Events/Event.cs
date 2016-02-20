using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Kenbo.Core.Events.Contracts;

namespace Kenbo.Core.Events
{
    public static class Event
    {
        [ThreadStatic]
        private static ICollection<Delegate> _callbacks;

        public static IIocContainer Container { get; set; }

        public static void Raise<T>(T argument)
            where T : EventArgs
        {
            if (Container != null)
            {
                foreach (var handler in Container.ResolveAll<T>())
                {
                    handler.Handle(argument);
                }
            }

            if (_callbacks != null)
            {
                foreach (var handle in _callbacks.OfType<Action<T>>())
                {
                    handle(argument);
                }
            }
        }

        public static void Register<T>(Action<T> callback)
            where T : EventArgs
        {
            if (_callbacks == null)
            {
                _callbacks = new Collection<Delegate>();
            }

            _callbacks.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _callbacks.Clear();
        }
    }
}
