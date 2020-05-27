using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrder
{
    public class GetOrderQuery : IQuery<OrderDto>
    {
        public Guid OrderId { get; set; }
    }
}
