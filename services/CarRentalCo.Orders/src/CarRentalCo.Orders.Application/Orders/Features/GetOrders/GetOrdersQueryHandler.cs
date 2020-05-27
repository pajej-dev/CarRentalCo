using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, ICollection<OrderDto>>
    {
        private readonly IGetOrdersService getOrdersService;

        public GetOrdersQueryHandler(IGetOrdersService getOrdersService)
        {
            this.getOrdersService = getOrdersService;
        }

        public async Task<ICollection<OrderDto>> HandleAsync(GetOrdersQuery query)
        {
            var orders = await getOrdersService.GetAllAsync(query.PageNumber, query.PageSize);

            return orders;
        }
    }
}
