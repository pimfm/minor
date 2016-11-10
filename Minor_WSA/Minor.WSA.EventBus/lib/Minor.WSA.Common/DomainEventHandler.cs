using System;

namespace Minor.WSA.Common
{
    public abstract class DomainEventHandler<TEvent> : IEventHandler
        where TEvent : DomainEvent
    {
        [EventHandler]
        public abstract void Handle(TEvent domainEvent);
    }

    public interface IEventHandler
    {
    }
}
