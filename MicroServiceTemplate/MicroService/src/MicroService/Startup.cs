using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            System.Console.WriteLine("services configured");
        }
        
        public void ConfigureEventSubscribers(IBus eventBus)
        {
            System.Console.WriteLine("subscribers configured");
        }
    }
}
