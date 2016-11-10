using System;
using Minor.WSA.Common;
using Minor.WSA.EventBus.Shared;
using Newtonsoft.Json;
using System.Text;

namespace Minor.WSA.EventBus.Publish
{
    public class EventPublisher : IEventPublisher
    {
        private IChannel _channel;
        private readonly EventBusOptions _options;

        public EventPublisher(EventBusOptions options)
        {
            _options = options;
            _channel = new Channel(options.Host);
        }

        public EventPublisher() : this(new EventBusOptions("localhost", "BKEEventBus"))
        {

        }
        
        public void Publish(DomainEvent domainEvent)
        {
            string routingKey = GenerateRoutingKey(domainEvent);

            string json = JsonConvert.SerializeObject(domainEvent);
            byte[] body = Encoding.UTF8.GetBytes(json);

            _channel.Publish(_options.ExchangeName, routingKey, body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        private string GenerateRoutingKey(DomainEvent domainEvent)
        {
            Type type = domainEvent.GetType();

            return type.Namespace + type.Name;
        }
    }
}
