using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.GetOrders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Services
{
    public class GetOrdersService : IGetOrdersService
    {
        public GetOrdersService()
        {

        }

        public async Task<ICollection<OrderDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            //todo mock
            var orderDto = new OrderDto { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), TotalPrice = 2252 };
            var orderDto2 = new OrderDto { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), TotalPrice = 22152 };
            var orderDto3 = new OrderDto { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), TotalPrice = 22352 };

            return await Task.FromResult(new List<OrderDto>() { orderDto, orderDto2, orderDto3 });
        }
    }
}
