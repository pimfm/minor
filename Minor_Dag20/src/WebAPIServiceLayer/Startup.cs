using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPIServiceLayer.Domain.Repositories;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using WebAPIServiceLayer.Infrastructure.Repositories;
using WebAPIServiceLayer.Infrastructure.Services;

namespace WebAPIServiceLayer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IManufacturesContext<SupermarketDbContext>, SupermarketDbContextFactory>();
            services.AddScoped<IServiceLocator, ServiceLocator>();

            services.AddEntityFrameworkInMemoryDatabase();

            services.AddDbContext<SupermarketDbContext>(options => {
                options.UseInMemoryDatabase();
            }, ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Products overview",
                    template: "api/v1/products",
                    defaults: new { Controller = "Product", Action = "All" }
                );

                routes.MapRoute(
                    name: "Product add",
                    template: "api/v1/products/add/{Name}",
                    defaults: new { Controller = "Product", Action = "Add" }
                );

                routes.MapRoute(
                    name: "Product detail",
                    template: "api/v1/product/{id}",
                    defaults: new { Controller = "Product", Action = "Find" }
                );
            });
        }
    }
}
