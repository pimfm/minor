using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestitOut.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            IConfigurationBuilder config = new ConfigurationBuilder();
            ILoggerFactory loggerFactory = new LoggerFactory();

            Startup program = new Startup();

            program.LoadCurrentState();
            program.ConfigureServices(services);
            program.ConfigureAppSettings(config);
            program.Configure(services.BuildServiceProvider());
        }
    }
}
