using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.Owners
{
    public class OwnerId : TypedIdValueObject
    {
        public OwnerId(Guid guid) : base(guid)
        {
        }
    }
}
