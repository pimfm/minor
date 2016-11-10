using RabbitMQ.Client;

namespace Minor.WSA.EventBus.Shared
{
    internal class Channel : IChannel
    {
        private IModel _model;

        public Channel(string host)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = host };
            _model = factory.CreateConnection().CreateModel();
        }

        public void Publish(string exchangeName, string routingKey, byte[] body)
        {
            _model.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            _model.BasicPublish(exchangeName, routingKey, false, null, body);
        }

        public void Dispose()
        {
            _model?.Dispose();
        }
    }
}
