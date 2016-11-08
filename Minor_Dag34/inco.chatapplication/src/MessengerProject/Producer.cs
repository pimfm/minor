using RabbitMQ.Client;
using System.Text;

namespace MessengerProject
{
    public class Producer
    {
        private readonly Encoding _encoding;
        private readonly ExchangeName _exchange;
        private readonly IModel _channel;

        public Producer(IModel channel, ExchangeName exchange, Encoding encoding)
        {
            _exchange = exchange;
            _encoding = encoding;
            _channel = channel;
        }

        public void Produce(string message)
        {
            byte[] body = _encoding.GetBytes(message);
            _channel.BasicPublish(exchange: _exchange.ToString(),
                                 routingKey: "",
                                 mandatory: false,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
