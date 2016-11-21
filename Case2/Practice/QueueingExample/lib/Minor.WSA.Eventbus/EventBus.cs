using System;
using Minor.WSA.Common.Contracts;
using Minor.WSA.Common.Domain;

namespace Minor.WSA.Eventbus
{
    public class EventBus : IEventPublisher, IEventSubscriber
    {
        private EventBusOptions _options;

        public EventBus(EventBusOptions options = null)
        {
            _options = options ?? new EventBusOptions();
        }

        public void Publish(DomainEvent domainEvent)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent>()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
