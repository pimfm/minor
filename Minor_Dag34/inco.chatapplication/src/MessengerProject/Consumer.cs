using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System;

public class Consumer
{
    private EventingBasicConsumer _consumer;

    public Consumer(IModel channel, string queueName)
    {
        _consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume(queue: queueName,
                             noAck: true,
                             consumer: _consumer);
    }

    public void Consume(EventHandler<BasicDeliverEventArgs> receiveMessage)
    {
        _consumer.Received += receiveMessage;
    }
}