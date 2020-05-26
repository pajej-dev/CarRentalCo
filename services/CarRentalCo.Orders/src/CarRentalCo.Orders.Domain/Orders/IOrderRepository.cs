using System.Threading.Tasks;

namespace CarRentalCo.Orders.Domain.Orders
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);

        Task<Order> GetByIdAsync(OrderId orderId);
    }
}
