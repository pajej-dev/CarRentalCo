using AutoMapper;
using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Domain.Orders;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Orders
{
    public class OrderMongoRepository : IOrderRepository
    {
        private readonly IMongoRepository<OrderDocument> repository;
        private readonly IMapper mapper;

        public OrderMongoRepository(IMongoRepository<OrderDocument> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddAsync(Order order)
        {
            await repository.AddAsync(mapper.Map<OrderDocument>(order));
        }

        public async Task<bool> ExistsAsync(OrderId id)
        {
            return await repository.ExistsAsync(x => x.Id == id.Value);
        }


        public async Task<Order> GetByIdAsync(OrderId orderId)
        {
            var orderDoc = await repository.GetAsync(o => o.Id == orderId.Value);
            return mapper.Map<Order>(orderDoc);
        }

        public async Task UpdateAsync(Order order)
        {
            await repository.UpdateAsync(mapper.Map<OrderDocument>(order));
        }
    }
}