using System;
using System.Collections.Generic;

namespace Kenbo.Core.Events
{
    public static class EventQueue
    {
        [ThreadStatic] private static ICollection<EventArgs> _arguments;

        public static void Add<T>(T argument) where T : EventArgs
        {
            _arguments.Add(argument);
        }

        public static void Clear()
        {
            _arguments.Clear();
        }

        public static void HandleQueue()
        {
            foreach (var argument in _arguments)
            {
                Event.Raise(argument);
            }

            Clear();
        }
    }
}