using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrder
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderDto>
    {
        private readonly IGetOrderService getOrderService;

        public GetOrderQueryHandler(IGetOrderService getOrderService)
        {
            this.getOrderService = getOrderService;
        }

        public async Task<OrderDto> HandleAsync(GetOrderQuery query)
        {
            var order = await getOrderService.GetById(query.OrderId);

            return order;
        }
    }
}
