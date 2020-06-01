using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars;
using CarRentalCo.Administration.Infrastructure.Mappings;
using CarRentalCo.Administration.Infrastructure.Mongo.RentalCars;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalCo.Common.Infrastructure.Mongo;


namespace CarRentalCo.Administration.Infrastructure.Services
{
    public class GetRentalCarsService : IGetRentalCarsService
    {
        private readonly IMongoRepository<RentalCarDocument> mongoRepository;

        public GetRentalCarsService(IMongoRepository<RentalCarDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }
        public async Task<ICollection<RentalCarDto>> GetAsync(Guid[] RentalCarIds)
        {
            var filterDef = new FilterDefinitionBuilder<RentalCarDocument>();
            var filter = filterDef.In(x => x.Id, RentalCarIds);

            var result = await mongoRepository.FindAsync(filter, null);
            return result.Select(x => x.ToDto()).ToList();
        }

    }
}
