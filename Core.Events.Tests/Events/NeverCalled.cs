using System;

namespace Kenbo.Core.Events.Tests
{
    public class NeverCalled : EventArgs
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public static NeverCalled Create()
        {
            return new NeverCalled {Id = Guid.Empty, Description = string.Empty};
        }
    }
}