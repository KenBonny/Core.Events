using System;

namespace Kenbo.Core.Events.Contracts
{
    public interface IEventHandler<in T> where T : EventArgs
    {
        void Handle(T argument);
    }
}