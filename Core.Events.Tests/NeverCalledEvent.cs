using System;

namespace Kenbo.Core.Events.Tests
{
    public class NeverCalledEvent : EventArgs
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public static NeverCalledEvent Create()
        {
            return new NeverCalledEvent {Id = Guid.Empty, Description = string.Empty};
        }
    }
}