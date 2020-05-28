using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Other;
using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerId = CarRentalCo.Orders.Domain.Orders.CustomerId;

namespace CarRentalCo.Orders.Application.Orders.Features.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IRentalCarClient rentalCarClient;
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;

        public CreateOrderCommandHandler(IRentalCarClient rentalCarClient, IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            this.rentalCarClient = rentalCarClient;
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
        }

        public async Task HandleAsync(CreateOrderCommand command, Guid correlationId = default)
        {
            //todo get rentalCarIds to check if exists and get prices
            var rentalCars = await rentalCarClient.GetByIdsAsync(command.OrderCars.Select(c => c.RentalCarId).ToArray());

            var customer = await customerRepository.GetByIdAsync(new Domain.Customers.CustomerId(command.CustomerId));
            if(customer == null)
            {
                throw new Exception("Cannot create order. Customer not exists."); //todo create application exceptions
            }

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
