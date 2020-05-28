using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.CreateOrder;
using CarRentalCo.Orders.Application.Orders.Features.GetOrders;
using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Clients;
using CarRentalCo.Orders.Infrastructure.Database;
using CarRentalCo.Orders.Infrastructure.Domain.Customers;
using CarRentalCo.Orders.Infrastructure.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarRentalCo.Orders.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration)
            //    .CreateLogger();

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRentalCarClient, RentalCarClient>();
            services.AddTransient<IGetOrdersService, GetOrdersService>();
       //db
       var connectionString = Configuration.GetConnectionString("CarRentalCo");
            services.AddDbContextPool<OrdersDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                });


            services.Scan(x => x.FromAssemblyOf<OrderCarDto>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());




            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentalCo.Orders", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentalCo.Orders V1");
            });


            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
