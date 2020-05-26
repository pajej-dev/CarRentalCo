using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class CustomerId : TypedIdValueObject
    {
        public CustomerId(Guid guid) : base(guid)
        {
        }
    }
}