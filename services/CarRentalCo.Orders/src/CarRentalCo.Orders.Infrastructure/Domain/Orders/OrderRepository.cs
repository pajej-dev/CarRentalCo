using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext ordersContext;

        public OrderRepository(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }

        public async Task AddAsync(Order order)
        {
            await ordersContext.AddAsync(order);
        }

        public async Task<Order> GetByIdAsync(OrderId orderId)
        {
            return await ordersContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }
    }
}
