using CarRentalCo.Common.Application.Contracts;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Orders.Application.Orders.Features.CreateOrder
{
    public class CreateOrderCommand : ICommand
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public ICollection<CreateOrderOrderCarModel> OrderCars { get; private set; }

        public CreateOrderCommand(Guid orderId, Guid customerId, ICollection<CreateOrderOrderCarModel> orderCars)
        {
            OrderId = orderId == Guid.Empty ? Guid.NewGuid() : orderId;
            CustomerId = customerId;
            OrderCars = orderCars;
        }
    }

    public class CreateOrderOrderCarModel
    {
        public Guid RentalCarId { get; private set; }
        public DateTime RentalStartDate { get; private set; }
        public DateTime RentalEndDate { get; private set; }
    }
}
