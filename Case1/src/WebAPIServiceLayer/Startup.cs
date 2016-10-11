using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using WebAPIServiceLayer.Infrastructure.Repositories;
using WebAPIServiceLayer.Infrastructure.Services;
using Swashbuckle.Swagger.Model;

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
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IManufacturesContext<CourseAdministrationDbContext>, CourseAdministrationDbContextFactory>();
            services.AddScoped<IServiceLocator, ServiceLocator>();

            services.AddEntityFrameworkInMemoryDatabase();

            services.AddDbContext<CourseAdministrationDbContext>(options => {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CourseAdministration;Trusted_Connection=True;");
            }, ServiceLifetime.Transient);

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Course Administration Service",
                    Description = "A RESTfull service for course administration",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
