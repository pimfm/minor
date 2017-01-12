using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            IBus messageBus = RabbitHutch.CreateBus();
            Startup program = new Startup();

            program.ConfigureServices(services);
            program.ConfigureEventSubscribers(messageBus);
        }
    }
}
