using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Domain.Orders;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrder
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderDto> HandleAsync(GetOrderQuery query)
        {
            var order = await orderRepository.GetByIdAsync(new OrderId(query.OrderId));

            //todo make mapper
            return order == null ? default : 
                new OrderDto
                {
                    Id = order.Id.Id,
                    CustomerId = order.CustomerId.Id,
                    TotalPrice = order.TotalPrice,
                    CreatedAt = order.CreatedAt,
                    OrderStatus = Map(order.OrderStatus),
                    OrderCars = order.OrderCars.Select(x => new OrderCarDto
                    {
                        Id = x.Id.Id,
                        PricePerDay = x.PricePerDay,
                        RentalCarId = x.RentalCarId.Id,
                        RentalEndDate = x.RentalEndDate,
                        RentalStartDate = x.RentalStartDate
                    }).ToList()
                };
        }

        private Dtos.OrderStatus Map(Domain.Orders.OrderStatus domainStatus)
        {
            switch (domainStatus)
            {
                case Domain.Orders.OrderStatus.New:
                    return Dtos.OrderStatus.New;
                case Domain.Orders.OrderStatus.Finished:
                    return Dtos.OrderStatus.Finished;
                case Domain.Orders.OrderStatus.Canceled:
                    return Dtos.OrderStatus.Canceled;
                default:
                    return Dtos.OrderStatus.New;
            }
        }
    }
}
