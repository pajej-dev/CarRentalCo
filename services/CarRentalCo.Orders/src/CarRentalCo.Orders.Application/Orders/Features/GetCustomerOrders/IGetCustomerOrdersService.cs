using CarRentalCo.Orders.Application.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public interface IGetCustomerOrdersService
    {
        Task<ICollection<OrderDto>> GetByCustomerAsync(Guid customerId);
    }
}