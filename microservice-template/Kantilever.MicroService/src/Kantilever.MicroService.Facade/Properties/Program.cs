using Kantilever.MicroService.Domain.Commands;
using Kantilever.MicroService.DomainServices.Contracts;
using Kantilever.MicroService.Infrastructure.Messaging;
using MicroService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kantilever.MicroService.Facade
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

            IServiceProvider provider = services.BuildServiceProvider();
            IMessageBus messageBus = provider.GetService<IMessageBus>();

            program.ConfigureSubscribers(messageBus, provider);

            messageBus.Publish(new DoSomething());
            messageBus.Publish(new DoSomethingElse());

        }
    }
}
