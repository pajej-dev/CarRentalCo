using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersQueryHandler : IQueryHandler<GetCustomerOrdersQuery, PagedResult<OrderDto>>
    {
        private readonly IGetCustomerOrdersService service;

        public GetCustomerOrdersQueryHandler(IGetCustomerOrdersService service)
        {
            this.service = service;
        }

        public async Task<PagedResult<OrderDto>> HandleAsync(GetCustomerOrdersQuery query)
        {
            var result = await service.GetAsync(new GetCustomerOrdersServiceQuery
            { 
                CustomerId = new CustomerId(query.CustomerId),
                Results = 10,
                Page = 1
            });

            return result;
        }
    }
}
