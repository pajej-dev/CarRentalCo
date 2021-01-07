using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Domain.Customers;
using System.Threading.Tasks;
using CarRentalCo.Orders.Infrastructure.Mappings;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Customers
{
    public class CustomerMongoRepository : ICustomerRepository
    {
        private readonly IMongoRepository<CustomerDocument> repository;

        public CustomerMongoRepository(IMongoRepository<CustomerDocument> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Customer customer)
        {
            await repository.AddAsync(customer.ToDocument());
        }

        public async Task<bool> ExistsAsync(CustomerId id)
        {
            return await repository.ExistsAsync(x => x.Id == id.Value);
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            var customerDoc = await repository.GetAsync(o => o.Id == id.Value);
            return customerDoc?.ToAggregate();
        }
    }
}
