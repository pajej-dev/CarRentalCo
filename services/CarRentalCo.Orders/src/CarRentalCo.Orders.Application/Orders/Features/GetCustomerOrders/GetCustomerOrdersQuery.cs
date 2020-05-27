using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersQuery : IQuery<ICollection<OrderDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
