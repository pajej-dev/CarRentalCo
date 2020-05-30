using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersQuery : IQuery<PagedResult<OrderDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
