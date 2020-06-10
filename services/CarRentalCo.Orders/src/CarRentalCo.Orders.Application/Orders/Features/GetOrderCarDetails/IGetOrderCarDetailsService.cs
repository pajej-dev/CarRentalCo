using CarRentalCo.Orders.Application.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrderDetails
{
    public interface IGetOrderCarDetailsService
    {
        Task<OrderCarDetailsDto> GetAsync(Guid orderCarId);
    }
}
