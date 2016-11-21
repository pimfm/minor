using Minor.WSA.Common.Domain;
using System;

namespace Minor.WSA.Common.Contracts
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}