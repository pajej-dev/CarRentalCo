using CarRentalCo.Orders.Domain.Customers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Customers
{
    public class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
    {
        public CustomerIdValueConverter(ConverterMappingHints converterMappingHints = null)
           : base(
                   id => id.Id,
                   val => new CustomerId(val), converterMappingHints
                 )
        { }

    }
}
