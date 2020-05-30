using System.Threading.Tasks;

namespace CarRentalCo.Orders.Domain.Orders
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task<bool> ExistsAsync(OrderId id);
        Task<Order> GetByIdAsync(OrderId orderId);
    }
}
