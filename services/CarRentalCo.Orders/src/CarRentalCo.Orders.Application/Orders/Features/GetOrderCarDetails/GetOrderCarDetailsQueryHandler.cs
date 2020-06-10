using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Clients;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.GetOrderDetails
{
    public class GetOrderCarDetailsQueryHandler : IQueryHandler<GetOrderCarDetailsQuery, OrderCarDetailsDto>
    {
        private readonly IGetOrderCarDetailsService getOrderDetailsService;
        private readonly IRentalCarClient rentalCarClient;

        public GetOrderCarDetailsQueryHandler(IGetOrderCarDetailsService getOrderDetailsService, IRentalCarClient rentalCarClient)
        {
            this.getOrderDetailsService = getOrderDetailsService;
            this.rentalCarClient = rentalCarClient;
        }

        public async Task<OrderCarDetailsDto> HandleAsync(GetOrderCarDetailsQuery query)
        {
            var orderDetails = await getOrderDetailsService.GetAsync(query.OrderCarId);

            if(orderDetails == null)
            {
                return null;
            }

            var rentalcarDetails = await rentalCarClient.GetByIdAsync(orderDetails.RentalCarId);

            if(rentalcarDetails != null)
            {
                orderDetails.Brand = rentalcarDetails.Specification.Brand;
                orderDetails.Model = rentalcarDetails.Specification.Model;
                orderDetails.ProductionDate = rentalcarDetails.Specification.ProductionDate;
                orderDetails.Colour = rentalcarDetails.Specification.Colour;
                orderDetails.Description = rentalcarDetails.Description;
                orderDetails.ImageUrl = rentalcarDetails.ImageUrl;
            }

            return orderDetails;
        }
    }
}
