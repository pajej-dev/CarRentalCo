using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Customers.Events
{
    public class CustomerCreatedDomainEvent : DomainEvent
    {
        public CustomerId CustomerId { get; }

        public CustomerCreatedDomainEvent(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
