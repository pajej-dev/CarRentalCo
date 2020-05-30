using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Domain.Orders;

namespace CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders
{
    public class GetCustomerOrdersServiceQuery : PagedQueryBase
    {
        public CustomerId CustomerId { get; set; }
    }
}