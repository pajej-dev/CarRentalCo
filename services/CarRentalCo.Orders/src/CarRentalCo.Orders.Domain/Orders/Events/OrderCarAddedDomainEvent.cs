using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Events
{
    public class OrderCarAddedDomainEvent : DomainEvent
    {
        public OrderId OrderId { get; }
        public RentalCarId RentalCarId { get; }
        public CustomerId CustomerId { get; }

        public OrderCarAddedDomainEvent(OrderId orderId, RentalCarId rentalCarId, CustomerId customerId)
        {
            OrderId = orderId;
            RentalCarId = rentalCarId;
            CustomerId = customerId;
        }

    }
}
