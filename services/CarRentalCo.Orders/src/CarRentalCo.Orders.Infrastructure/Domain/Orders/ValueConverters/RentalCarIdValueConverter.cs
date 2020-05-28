using CarRentalCo.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders.ValueConverters
{
    public class RentalCarIdValueConverter : ValueConverter<RentalCarId, Guid>
    {
        public RentalCarIdValueConverter(ConverterMappingHints converterMappingHints = null)
            : base(
                    id => id.Value,
                    val => new RentalCarId(val), converterMappingHints
                  )
        { }

    }
}
