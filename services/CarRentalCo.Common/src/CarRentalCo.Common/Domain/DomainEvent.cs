using CarRentalCo.Common.Other;
using System;

namespace CarRentalCo.Common.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime EventUtcDate => SystemTime.UtcNow;
    }
}
