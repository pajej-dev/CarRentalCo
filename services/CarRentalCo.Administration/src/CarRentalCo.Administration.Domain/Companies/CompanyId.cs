using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class CompanyId : TypedIdValueObject
    {
        public CompanyId(Guid guid) : base(guid)
        {
        }
    }
}
