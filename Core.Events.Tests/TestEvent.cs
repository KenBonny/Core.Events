using System;

namespace Kenbo.Core.Events.Tests
{
    public class TestEvent : EventArgs
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public static TestEvent Create(string description)
        {
            return new TestEvent {Id = Guid.NewGuid(), Description = description};
        }
    }
}