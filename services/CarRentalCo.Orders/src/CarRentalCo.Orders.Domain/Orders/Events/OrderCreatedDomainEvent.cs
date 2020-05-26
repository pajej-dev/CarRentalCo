using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Events
{
    public class OrderCreatedDomainEvent : DomainEvent
    {
        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }

        public OrderCreatedDomainEvent(OrderId orderId, CustomerId customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

    }
}
