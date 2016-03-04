using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Kenbo.Core.Events.Contracts;

namespace Kenbo.Core.Events
{
    public static class Event
    {
        private static readonly ICollection<Delegate> Callbacks = new Collection<Delegate>();

        public static IIocContainer Container { get; set; }

        public static void Raise<T>(T eventArgument)
            where T : EventArgs
        {
            if (!Callbacks.Any())
            {
                foreach (var handle in Callbacks.OfType<Action<T>>())
                {
                    handle(eventArgument);
                }
            }

            if (Container != null)
            {
                foreach (var handler in Container.ResolveAll<T>())
                {
                    handler.Handle(eventArgument);
                }
            }
        }

        public static void Register<T>(Action<T> callback)
            where T : EventArgs
        {
            Callbacks.Add(callback);
        }

        public static void ClearCallbacks()
        {
            Callbacks.Clear();
        }
    }
}
