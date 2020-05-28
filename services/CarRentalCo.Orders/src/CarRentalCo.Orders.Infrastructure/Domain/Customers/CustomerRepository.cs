using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersDbContext ordersContext;

        public CustomerRepository(OrdersDbContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }

        public async Task AddAsync(Customer customer)
        {
            await ordersContext.AddAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(CustomerId customerId)
        {
            return await ordersContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
        }
    }
}
