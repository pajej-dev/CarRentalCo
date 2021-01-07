using CarRentalCo.Administration.API.Extensions;
using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars;
using CarRentalCo.Administration.Infrastructure.Mongo.Companies;
using CarRentalCo.Administration.Infrastructure.Services;
using CarRentalCo.Common.Middlewares;
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

namespace CarRentalCo.Administration.API
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
            services.AddCompanyMongo(Configuration);
            services.AddSwagger();
            services.AddScrutorScan();
            services.AddHealthChecks();
            services.AddTransient<IGetRentalCarsService,GetRentalCarsService>();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRentalCo.Administration V1");
                c.RoutePrefix = "administrationApi/swagger";
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("administrationApi/health");
                endpoints.MapGet("administrationApi/info",  async req => 
                {
                    var adresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                    string text = $"Service : CarrentalCo.Administration |  Ips: {string.Join(';', adresses.Select(x => x.ToString()))}";

                    await req.Response.WriteAsync(text);
                });
            });
        }
    }
}
