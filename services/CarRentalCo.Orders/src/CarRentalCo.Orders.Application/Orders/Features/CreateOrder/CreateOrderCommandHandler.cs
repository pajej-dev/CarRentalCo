using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Other;
using CarRentalCo.Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Orders.Features.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IRentalCarClient rentalCarClient;
        private readonly IOrderRepository orderRepository;

        public CreateOrderCommandHandler(IRentalCarClient rentalCarClient, IOrderRepository orderRepository)
        {
            this.rentalCarClient = rentalCarClient;
            this.orderRepository = orderRepository;
        }

        public async Task HandleAsync(CreateOrderCommand command, Guid correlationId = default)
        {
            //todo check if orderId exists in db or move it to domain

            var carPrices = await rentalCarClient.GetByIdsAsync(command.OrderCars.Select(c => c.RentalCarId).ToArray());

            //match prices to orderCars
            var orderCars = new List<OrderCar>();
            foreach(var oc in command.OrderCars)
            {
                //var car = carPrices.FirstOrDefault(x => x.Id == oc.RentalCarId);
                //if (car == null)
                //    continue;

                orderCars.Add(OrderCar.Create(new RentalCarId(oc.RentalCarId), 25/*car.PricePerDay*/, oc.RentalStartDate, oc.RentalEndDate));
            }

            var order = Order.Create(new OrderId(command.OrderId), new CustomerId(command.CustomerId), SystemTime.UtcNow, orderCars);
            await orderRepository.AddAsync(order);
            //todo commit
        }
    }
}
