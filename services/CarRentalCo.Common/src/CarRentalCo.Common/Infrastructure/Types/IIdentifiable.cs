using System;

namespace CarRentalCo.Common.Infrastructure.Types
{
    public interface IIdentifiable
    {
         Guid Id { get; }
    }
}