using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class RentalCarId : TypedIdValueObject
    {
        public RentalCarId(Guid guid) : base(guid)
        {
        }
    }
}
