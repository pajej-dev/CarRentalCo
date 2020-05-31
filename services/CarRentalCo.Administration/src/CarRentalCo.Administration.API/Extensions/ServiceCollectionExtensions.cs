using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Infrastructure.Mongo.Companies;
using CarRentalCo.Administration.Infrastructure.Mongo.Owners;
using CarRentalCo.Administration.Infrastructure.Mongo.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Infrastructure.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CarRentalCo.Administration.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCompanyMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongo(configuration);
            services.AddMongoRepository<CompanyDocument>("companies");
            services.AddMongoRepository<OwnerDocument>("owners");
            services.AddMongoRepository<RentalCarDocument>("rentalCars");
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
                typeof(CompanyDto).Assembly,
                typeof(CompanyDocument).Assembly)
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
