using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrders
{
    public interface IGetOrdersService
    {
        Task<PagedResult<OrderDto>> GetAsync(GetOrdersServiceQuery query);
    }
}
