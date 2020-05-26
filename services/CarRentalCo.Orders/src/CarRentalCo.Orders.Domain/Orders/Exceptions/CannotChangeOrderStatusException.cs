using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class CannotChangeOrderStatusException : DomainException
    {
        public override string Code => "cannot_change_order_status";

        public CannotChangeOrderStatusException(OrderId orderId, OrderStatus currentStatus, OrderStatus newStatus) :
            base($"Cannot change state for order with id: '{orderId}' from {currentStatus} to {newStatus}'")
        {
        }
    }
}
