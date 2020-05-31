using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Administration.Infrastructure.Mappings;
using CarRentalCo.Common.Infrastructure.Mongo;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Infrastructure.Mongo.RentalCars
{
    public class RentalCarMongoRepository : IRentalCarsRepository
    {
        private readonly IMongoRepository<RentalCarDocument> mongoRepository;

        public RentalCarMongoRepository(IMongoRepository<RentalCarDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task AddAsync(RentalCar company)
        {
            await mongoRepository.AddAsync(company.ToDocument());
        }

        public async Task<bool> ExistsAsync(RentalCarId id)
        {
            return await mongoRepository.ExistsAsync(x => x.Id == id.Value);
        }

        public async Task<RentalCar> GetByIdAsync(RentalCarId id)
        {
            var custDocument = await mongoRepository.GetAsync(o => o.Id == id.Value);

            return custDocument?.ToAggregate();
        }

        public async Task UpdateAsync(RentalCar company)
        {
            await mongoRepository.UpdateAsync(company.ToDocument());
        }
    }
}
