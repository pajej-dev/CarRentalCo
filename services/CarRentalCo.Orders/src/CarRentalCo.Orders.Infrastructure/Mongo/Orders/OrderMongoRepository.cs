using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Mappings;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Orders
{
    public class OrderMongoRepository : IOrderRepository
    {
        private readonly IMongoRepository<OrderDocument> repository;

        public OrderMongoRepository(IMongoRepository<OrderDocument> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Order order)
        {
            await repository.AddAsync(order.ToDocument());
        }

        public async Task<bool> ExistsAsync(OrderId id)
        {
            return await repository.ExistsAsync(x => x.Id == id.Value);
        }


        public async Task<Order> GetByIdAsync(OrderId orderId)
        {
            var orderDocument = await repository.GetAsync(o => o.Id == orderId.Value);

            return orderDocument?.ToAggregate();
        }

        public async Task UpdateAsync(Order order)
        {
            await repository.UpdateAsync(order.ToDocument());
        }
    }
}