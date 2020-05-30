using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, PagedResult<OrderDto>>
    {
        private readonly IGetOrdersService getOrdersService;

        public GetOrdersQueryHandler(IGetOrdersService getOrdersService)
        {
            this.getOrdersService = getOrdersService;
        }

        public async Task<PagedResult<OrderDto>> HandleAsync(GetOrdersQuery query)
        {
            var orders = await getOrdersService.GetAsync(new GetOrdersServiceQuery { Page = query.PageNumber, Results = query.PageSize });

            return orders;
        }
    }
}
