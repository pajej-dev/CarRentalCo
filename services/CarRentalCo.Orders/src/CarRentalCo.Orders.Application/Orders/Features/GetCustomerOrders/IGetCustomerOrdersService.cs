using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public interface IGetCustomerOrdersService
    {
        Task<PagedResult<OrderDto>> GetAsync(GetCustomerOrdersServiceQuery query);
    }
}