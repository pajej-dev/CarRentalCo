using CarRentalCo.Common.Middlewares;
using CarRentalCo.Orders.API.Extensions;
using CarRentalCo.Orders.Application.Orders.Clients;
using CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders;
using CarRentalCo.Orders.Application.Orders.Features.GetOrderDetails;
using CarRentalCo.Orders.Application.Orders.Features.GetOrders;
using CarRentalCo.Orders.Infrastructure.Clients;
using CarRentalCo.Orders.Infrastructure.Services;
using CorrelationId;
using CorrelationId.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Net;

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
            services.AddLogging();
            services.AddDefaultCorrelationId();
            services.AddTransient<IGetOrdersService, GetOrdersService>();
            services.AddTransient<IGetCustomerOrdersService, GetCustomerOrdersService>();
            services.AddTransient<IGetOrderCarDetailsService, GetOrderCarDetailsService>();
            services.AddTransient<IRentalCarClient, RentalCarClient>();
            services.AddOrdersMongo(Configuration);
            services.AddSwagger();
            services.AddScrutorScan();
            services.AddHealthChecks();
            services.AddSettings(Configuration);
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCorrelationId();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentalCo.Orders V1");
                c.RoutePrefix = "ordersApi/swagger";
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllers();
                endpoints.MapHealthChecks("ordersApi/health");
                endpoints.MapGet("ordersApi/info", async req =>
                {
                    var adresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                    string text = $"Service : CarrentalCo.Orders |  Ips: {string.Join(';', adresses.Select(x => x.ToString()))}";

                    await req.Response.WriteAsync(text);
                });
            });
        }
    }
}
