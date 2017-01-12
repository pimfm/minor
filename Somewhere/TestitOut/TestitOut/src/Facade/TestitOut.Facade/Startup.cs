using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using EasyNetQ;
using SharpRaven.Core;
using Microsoft.Extensions.Logging;
using Serilog;
using TestitOut.DAL.Repositories;
using Bagagedrager.Common.Events;
using TestitOut.Services;
using TestitOut.Services.EasyNetQ;
using TestitOut.Entities;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace TestitOut.Facade
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        private IEventHandler _handler;

        public void LoadCurrentState()
        {
            //TODO: When the microservices is starting up
            //this method should get all events from the auditlog.
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ExampleContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySQL")))
                .AddScoped<IRepository<Example, int>, ExampleRepository>()
                .AddSingleton<IEventHandler>(new EventHandler(Configuration.GetConnectionString("RabbitMQ")));
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

        public void Configure(System.IServiceProvider services)
        {
            services.GetService<ExampleContext>().Database.EnsureCreated();
            BindQueues();
            AttachEventListeners(services);
        }

        private void BindQueues()
        {
            _handler.Bus.Bind(_handler.Exchange, _handler.Queue, new ExampleEvent().GetType().FullName);
        }

        private void AttachEventListeners(System.IServiceProvider services)
        {
            ExampleService exampleService = services.GetService<ExampleService>();
            _handler.Bus.Consume(_handler.Queue, consumers => consumers.Add<ExampleEvent>((message, info) => exampleService.Handle(message.Body)));
        }
    }
}
