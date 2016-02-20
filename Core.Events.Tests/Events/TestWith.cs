using System;

namespace Kenbo.Core.Events.Tests
{
    public class TestWith : EventArgs
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public static TestWith Create(string description)
        {
            return new TestWith {Id = Guid.NewGuid(), Description = description};
        }
    }
}