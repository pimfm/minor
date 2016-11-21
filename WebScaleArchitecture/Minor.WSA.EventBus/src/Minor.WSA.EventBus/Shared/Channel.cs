using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Minor.WSA.EventBus.Shared
{
    internal class Channel : IDisposable
    {
        private IModel _model;
        private IConnection _connection;
        private EventBusOptions _options;

        public Channel(EventBusOptions options)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = options.Host };

            _options    = options;
            _connection = factory.CreateConnection();
            _model      = _connection.CreateModel();
        }

        public void Send(string routingKey, byte[] body)
        {
            _model.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic);
            _model.BasicPublish(_options.ExchangeName, routingKey, false, null, body);
        }

        public void Receive(EventHandler<BasicDeliverEventArgs> onReceive)
        {
            _model.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic);
            _model.BasicConsume();
        }

        public void Dispose()
        {
            _model?.Dispose();
            _connection?.Dispose();
        }
    }
}
