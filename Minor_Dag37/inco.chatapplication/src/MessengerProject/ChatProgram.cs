using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics;
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
                Queue queue         = new Queue(channel, ExchangeName.Messages);
                Consumer consumer   = new Consumer(channel, queue.Name);
                Producer producer   = new Producer(channel, ExchangeName.Messages, Encoding.UTF8);
                Stopwatch stopwatch = new Stopwatch();

                consumer.Consume(WriteToConsole);
                stopwatch.Start();

                while (true)
                {
                    if (stopwatch.Elapsed.Seconds >= 1)
                    {
                        producer.Produce("Hi there!");
                        stopwatch.Restart();
                    }
                }
            }
        }

        private static void WriteToConsole(object sender, BasicDeliverEventArgs e)
        {
            string message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine($"{e.DeliveryTag} says: {message}");
        }
    }
}
