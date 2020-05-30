using CarRentalCo.Common.Infrastructure.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalCo.Common.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MongoDbOptions>(configuration.GetSection("mongo"));

            services.AddSingleton<MongoClient>(fac =>
            {
                var opt = fac.GetService<IOptions<MongoDbOptions>>();
                return new MongoClient(opt.Value.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(fac =>
            {
                var opt = fac.GetService<IOptions<MongoDbOptions>>();
                var client = fac.GetService<MongoClient>();
                return client.GetDatabase(opt.Value.Database);
            });

            services.AddScoped<IMongoDbInitializer, MongoDbInitializer>();
            services.AddScoped<IMongoDbSeeder, MongoDbSeeder>();
        }

        public static void AddMongoRepository<TEntity>(this IServiceCollection services, string collectionName)
            where TEntity : IIdentifiable
        {
            services.AddScoped<IMongoRepository<TEntity>>(fac =>
            {
                var mongodb = fac.GetService<IMongoDatabase>();

                return new MongoRepository<TEntity>(mongodb, collectionName);
            });
        }
    }
}