using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersQueryHandler : IQueryHandler<GetCustomerOrdersQuery, ICollection<OrderDto>>
    {
        private readonly IGetCustomerOrdersService getCustomerOrdersService;

        public GetCustomerOrdersQueryHandler(IGetCustomerOrdersService getCustomerOrdersService)
        {
            this.getCustomerOrdersService = getCustomerOrdersService;
        }

        public async Task<ICollection<OrderDto>> HandleAsync(GetCustomerOrdersQuery query)
        {
            var result = await getCustomerOrdersService.GetByCustomerAsync(query.CustomerId);

            return result;
        }
    }
}
