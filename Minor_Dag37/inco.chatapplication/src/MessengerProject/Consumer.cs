using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

public class Consumer
{
    private EventingBasicConsumer _consumer;

    public Consumer(IModel channel, string queueName)
    {
        channel.BasicConsume(queue: queueName,
                             noAck: true,
                             consumer: _consumer);

        _consumer = new EventingBasicConsumer(channel);
    }

    public void Consume(EventHandler<BasicDeliverEventArgs> receiveMessage)
    {
        _consumer.Received += receiveMessage;
    }
}