using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Collections.Generic;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrders
{
    public class GetOrdersQuery : IQuery<PagedResult<OrderDto>> 
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
