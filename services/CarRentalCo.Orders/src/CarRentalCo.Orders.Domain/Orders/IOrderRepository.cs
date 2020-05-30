using CarRentalCo.Common.Domain;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Domain.Orders
{
    public interface IOrderRepository : IDomainRepository
    {
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task<bool> ExistsAsync(OrderId id);
        Task<Order> GetByIdAsync(OrderId orderId);
    }
}
