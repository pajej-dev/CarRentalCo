using AutoMapper;
using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Domain.Customers;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Customers
{
    public class CustomerMongoRepository : ICustomerRepository
    {
        private readonly IMongoRepository<CustomerDocument> repository;
        private readonly IMapper mapper;

        public CustomerMongoRepository(IMongoRepository<CustomerDocument> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddAsync(Customer customer)
        {
            await repository.AddAsync(mapper.Map<CustomerDocument>(customer));
        }

        public async Task<bool> ExistsAsync(CustomerId id)
        {
            return await repository.ExistsAsync(x => x.Id == id.Value);
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            var customerDoc = await repository.GetAsync(o => o.Id == id.Value);
            return mapper.Map<Customer>(customerDoc);
        }
    }
}
