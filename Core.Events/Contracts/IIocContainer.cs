using System;
using System.Collections.Generic;

namespace Kenbo.Core.Events.Contracts
{
    public interface IIocContainer
    {
        IEnumerable<IEventHandler<T>> ResolveAll<T>() where T : EventArgs;
    }
}