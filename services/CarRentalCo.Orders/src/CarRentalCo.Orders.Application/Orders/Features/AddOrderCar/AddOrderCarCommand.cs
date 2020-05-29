using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Orders.Application.Orders.Features.AddOrderCar
{
    public class AddOrderCarCommand : ICommand
    {
        public Guid OrderId { get; private set; }

        public Guid RentalCarId { get; private set; }
        public DateTime RentalStartDate { get; private set; }
        public DateTime RentalEndDate { get; private set; }

        public AddOrderCarCommand(Guid orderId, Guid rentalCarId, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            OrderId = orderId == Guid.Empty ? Guid.NewGuid() : orderId;
            RentalCarId = rentalCarId;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
        }
    }
}
