using System;

namespace Minor.WSA.Common
{
    public abstract class DomainEventHandler<T>
        where T : DomainEvent
    {
        [EventHandler]
        public abstract void Handle(T domainEvent);
    }
}
