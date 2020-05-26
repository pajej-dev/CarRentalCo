using CarRentalCo.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalCo.Orders.Domain.Orders.Events
{
    public class OrderCanceledDomainEvent : DomainEvent
    {
        public OrderCanceledDomainEvent(OrderId orderId, CustomerId customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }
    }
}
