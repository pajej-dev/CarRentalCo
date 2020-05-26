using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public class RentalCarId : TypedIdValueObject
    {
        public RentalCarId(Guid guid) : base(guid)
        {
        }
    }
}
