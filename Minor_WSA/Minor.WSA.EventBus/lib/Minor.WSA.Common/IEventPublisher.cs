using System;

namespace Minor.WSA.Common
{
    public interface IEventPublisher : IDisposable
    {
        void Publish(DomainEvent domainEvent);
    }
}
