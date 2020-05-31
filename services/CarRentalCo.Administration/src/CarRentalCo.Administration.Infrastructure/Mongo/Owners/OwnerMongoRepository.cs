using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Infrastructure.Mappings;
using CarRentalCo.Common.Infrastructure.Mongo;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Infrastructure.Mongo.Owners
{
    public class OwnerMongoRepository : IOwnerRepository
    {
        private readonly IMongoRepository<OwnerDocument> mongoRepository;

        public OwnerMongoRepository(IMongoRepository<OwnerDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }


        public async Task AddAsync(Owner owner)
        {
            await mongoRepository.AddAsync(owner.ToDocument());
        }

        public async Task<bool> ExistsAsync(OwnerId id)
        {
            return await mongoRepository.ExistsAsync(x => x.Id == id.Value);
        }

        public async Task<Owner> GetByIdAsync(OwnerId ownerId)
        {
            var custDocument = await mongoRepository.GetAsync(o => o.Id == ownerId.Value);

            return custDocument?.ToAggregate();
        }
    }
}
