using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Orders.Clients;
using CarRentalCo.Orders.Domain.Orders;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.AddOrderCar
{
    public class AddOrderCarCommandHandler : ICommandHandler<AddOrderCarCommand>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IRentalCarClient rentalCarClient;

        public AddOrderCarCommandHandler(IOrderRepository orderRepository, IRentalCarClient rentalCarClient)
        {
            this.orderRepository = orderRepository;
            this.rentalCarClient = rentalCarClient;
        }

        public async Task HandleAsync(AddOrderCarCommand command, Guid correlationId = default)
        {
            var order = await orderRepository.GetByIdAsync(new OrderId(command.OrderId));
            if(order == null)
            {
                throw new Exception("Cannot Add order car. OrderId not found");
            }

            var rentalCar = await rentalCarClient.GetByIdAsync(command.RentalCarId);
            if(rentalCar == null)
            {
                throw new Exception("Cannot Add order car. RentalCarId not found");
            }

            order.AddOrderCar(new RentalCarId(command.RentalCarId), rentalCar.PricePerDay, command.RentalStartDate, command.RentalEndDate );   
        }
    }
}
