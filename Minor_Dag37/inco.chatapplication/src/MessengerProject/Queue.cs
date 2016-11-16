using RabbitMQ.Client;

namespace MessengerProject
{
    public class Queue
    {
        public readonly string Name;

        public Queue(IModel channel, ExchangeName exchangeName)
        {
            string exchange = exchangeName.ToString();
            channel.ExchangeDeclare(exchange: exchange, type: "fanout");
            
            string queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: exchange,
                              routingKey: "");

            Name = queueName;
        }
    }
}
