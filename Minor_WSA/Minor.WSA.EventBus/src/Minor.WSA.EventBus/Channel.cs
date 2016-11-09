using System;
using RabbitMQ.Client;

namespace Minor.WSA.EventBus
{
    public class Channel : IChannel
    {
        private IModel _channel;

        public Channel(string host)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = host };
            _channel = factory.CreateConnection().CreateModel();
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}
