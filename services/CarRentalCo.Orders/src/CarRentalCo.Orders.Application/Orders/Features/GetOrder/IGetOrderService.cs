using CarRentalCo.Orders.Application.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrder
{
    public interface IGetOrderService
    {
        Task<OrderDto> GetById(Guid orderId);
    }
}
