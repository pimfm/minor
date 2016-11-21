using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MessengerProject
{
    public class ChatProgram
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                Queue queue       = new Queue(channel, ExchangeName.Messages);
                Consumer consumer = new Consumer(channel, queue.Name);
                Producer producer = new Producer(channel, ExchangeName.Messages, Encoding.UTF8);

                consumer.Consume(WriteToConsole);

                for (int i = 0; i < 3; i++)
                {
                    producer.Produce(Console.ReadLine());
                }
            }
        }

        private static void WriteToConsole(object sender, BasicDeliverEventArgs e)
        {
            string message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine($"{e.DeliveryTag} says {message}");
        }
    }
}
