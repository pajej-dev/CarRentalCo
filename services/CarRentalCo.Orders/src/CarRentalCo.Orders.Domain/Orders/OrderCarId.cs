using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class OrderCarId : TypedIdValueObject
    {
        public OrderCarId(Guid guid) : base(guid)
        {
        }
    }
}