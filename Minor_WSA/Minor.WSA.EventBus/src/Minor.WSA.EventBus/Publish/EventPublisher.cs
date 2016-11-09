using System;
using Minor.WSA.Common;

namespace Minor.WSA.EventBus.Publish
{
    public class EventPublisher : IEventPublisher, IDisposable
    {
        private IChannel _channel;

        public EventPublisher(Channel channel)
        {
            _channel = channel;
        }
        
        public void Publish(DomainEvent domainEvent)
        {
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}
