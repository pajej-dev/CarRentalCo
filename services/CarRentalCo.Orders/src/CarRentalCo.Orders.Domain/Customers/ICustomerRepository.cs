using CarRentalCo.Common.Domain;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Domain.Customers
{
    public interface ICustomerRepository : IDomainRepository
    {
        Task AddAsync(Customer customer);

        Task<Customer> GetByIdAsync(CustomerId id);

        Task<bool> ExistsAsync(CustomerId id);
    }
}
