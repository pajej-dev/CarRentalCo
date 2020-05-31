using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Infrastructure.Mappings;
using CarRentalCo.Common.Infrastructure.Mongo;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Infrastructure.Mongo.Companies
{
    public class CompanyMongoRepository : ICompanyRepository
    {
        private readonly IMongoRepository<CompanyDocument> mongoRepository;

        public CompanyMongoRepository(IMongoRepository<CompanyDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task AddAsync(Company company)
        {
            await mongoRepository.AddAsync(company.ToDocument());
        }

        public async Task<bool> ExistsAsync(CompanyId id)
        {
            return await mongoRepository.ExistsAsync(x => x.Id == id.Value);
        }

        public async Task<Company> GetByIdAsync(CompanyId companyId)
        {
            var custDocument = await mongoRepository.GetAsync(o => o.Id == companyId.Value);

            return custDocument?.ToAggregate();
        }

        public async Task UpdateAsync(Company company)
        {
            await mongoRepository.UpdateAsync(company.ToDocument());
        }
    }
}
