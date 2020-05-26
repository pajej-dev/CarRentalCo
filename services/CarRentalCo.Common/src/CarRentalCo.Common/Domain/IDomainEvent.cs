using System;

namespace CarRentalCo.Common.Domain
{
    public  interface IDomainEvent
    {
        DateTime EventUtcDate { get; }
    }
}