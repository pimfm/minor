using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using EasyNetQ;
using SharpRaven.Core;
using Kantilever.MicroService.DomainServices.CommandHandlers;
using Kantilever.MicroService.DomainServices.EventHandlers;
using Kantilever.MicroService.Domain.Events;
using Kantilever.MicroService.Domain.Commands;
using Kantilever.MicroService.Infrastructure.Messaging;
using Kantilever.MicroService.DomainServices.Contracts;

namespace MicroService
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public void LoadCurrentState()
        {
            //TODO: When the microservices is starting up
            //this method should get all events from the auditlog.
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<ICommandHandler<DoSomething>, DoSomethingHandler>()
                .AddScoped<IEventHandler<SomethingElseIsDone>, SomethingElseIsDoneHandler>()
                .AddScoped<IMessageBus, MessageBus>()
                .AddScoped((provider) => RabbitHutch.CreateBus("host=kantilever-eventbus;username=Kantilever;password=Kant1lever").Advanced)
                .AddScoped<IRavenClient, RavenClient>((provider) => new RavenClient(Configuration["SentryEndpoint"]));
        }

        public void ConfigureAppSettings(IConfigurationBuilder config)
        {
            Configuration = config
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.Development.json", optional: true)
                .AddJsonFile($"appsettings.Production.json", optional: true)
                .Build();
        }

        public void ConfigureSubscribers(IMessageBus messageBus, System.IServiceProvider services)
        {
            messageBus.Subscribe<DoSomething>(services.GetService<ICommandHandler<DoSomething>>().Handle);
            messageBus.Subscribe<DoSomethingElse>(services.GetService<ICommandHandler<DoSomethingElse>>().Handle);
            messageBus.Subscribe<SomethingElseIsDone>(services.GetService<IEventHandler<SomethingElseIsDone>>().Handle);
        }
    }
}
