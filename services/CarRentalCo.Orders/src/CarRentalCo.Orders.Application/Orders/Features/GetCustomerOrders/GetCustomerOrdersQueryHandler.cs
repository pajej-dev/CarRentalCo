using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersQueryHandler : IQueryHandler<GetCustomerOrdersQuery, ICollection<OrderDto>>
    {
        private readonly IOrderRepository orderRepository;

        public GetCustomerOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<ICollection<OrderDto>> HandleAsync(GetCustomerOrdersQuery query)
        {
            var result = await orderRepository.GetByCustomerIdAsync(new CustomerId(query.CustomerId));

            var dtos = result.Select(order => new OrderDto 
            {
                Id = order.Id.Id,
                CustomerId = order.CustomerId.Id,
                TotalPrice = order.TotalPrice,
                OrderCars = order.OrderCars.Select(x => new OrderCarDto
                {
                    Id = x.Id.Id,
                    PricePerDay = x.PricePerDay,
                    RentalCarId = x.RentalCarId.Id,
                    RentalEndDate = x.RentalEndDate,
                    RentalStartDate = x.RentalStartDate
                }).ToList()
            });

            return dtos?.ToList();
        }
    }
}
