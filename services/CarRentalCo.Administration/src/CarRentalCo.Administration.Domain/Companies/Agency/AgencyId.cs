using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class AgencyId : TypedIdValueObject
    {
        public AgencyId(Guid guid) : base(guid)
        {
        }
    }
}