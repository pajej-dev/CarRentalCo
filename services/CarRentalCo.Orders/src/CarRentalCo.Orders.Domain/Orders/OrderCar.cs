using CarRentalCo.Common.Domain;
using CarRentalCo.Orders.Domain.Orders.Exceptions;
using System;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class OrderCar : IEntity<OrderCarId>
    {
        public OrderCarId Id { get; private set; }
        public RentalCarId RentalCarId { get; private set; }
        public double PricePerDay { get; private set; }
        public DateTime RentalStartDate { get; private set; }
        public DateTime RentalEndDate { get; private set; }

        private OrderCar()
        {
        }

        private OrderCar(OrderCarId id, RentalCarId rentalCarId, double pricePerDay, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            Id = (id == null || id.Value == Guid.Empty) ? new OrderCarId(Guid.NewGuid()) : id;

            RentalCarId = rentalCarId;
            PricePerDay = pricePerDay;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
        }

        public static OrderCar Create(OrderCarId id,RentalCarId rentalCarId, double pricePerDay, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            if ((rentalEndDate - rentalStartDate).TotalDays < 1)
                throw new OrderCarRentalTooShortException($"Cannot create car rental shorter than 1 day");

            return new OrderCar(id, rentalCarId, pricePerDay, rentalStartDate, rentalEndDate);
        }
    }
}