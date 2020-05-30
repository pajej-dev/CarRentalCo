using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Infrastructure.Mongo.Customers;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CarRentalCo.Orders.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrdersMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongo(configuration);
            services.AddMongoRepository<OrderDocument>("orders");
            services.AddMongoRepository<CustomerDocument>("customers");
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentalCo.Orders", Version = "v1" });
            });
        }

        public static void AddScrutorScan(this IServiceCollection services)
        {
            services.Scan(x => x.FromAssemblies(
                typeof(OrderDto).Assembly,
                typeof(OrderDocument).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo(typeof(IDomainRepository)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime());
        }


    }
}
