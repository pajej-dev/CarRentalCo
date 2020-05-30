using System.Threading.Tasks;

namespace CarRentalCo.Common.Infrastructure.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}