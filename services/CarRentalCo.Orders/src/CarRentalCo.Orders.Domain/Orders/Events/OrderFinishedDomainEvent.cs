using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Events
{
    public class OrderFinishedDomainEvent : DomainEvent
    {
        public OrderFinishedDomainEvent(OrderId orderId, CustomerId customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }
    }
}
