using System;

namespace CarRentalCo.Common.Domain
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
