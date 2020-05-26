using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class OrderId : TypedIdValueObject
    {
        public OrderId(Guid guid) : base(guid)
        {
        }
    }
}
