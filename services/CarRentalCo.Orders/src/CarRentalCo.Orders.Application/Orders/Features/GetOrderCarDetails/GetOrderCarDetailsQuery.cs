using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrderDetails
{
    public class GetOrderCarDetailsQuery : IQuery<OrderCarDetailsDto>
    {
        public Guid OrderCarId { get; set; }
    }
}
