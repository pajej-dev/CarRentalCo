using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrders
{
    public interface IGetOrdersService
    {
        Task<ICollection<OrderDto>> GetAllAsync(int pageNumber, int pageSize);
    }
}
