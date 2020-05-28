using CarRentalCo.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders
{
    public class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
    {
        public CustomerIdValueConverter(ConverterMappingHints converterMappingHints = null)
            : base(
                    id => id.Value,
                    val => new CustomerId(val), converterMappingHints
                  )
        { }
    }
}
