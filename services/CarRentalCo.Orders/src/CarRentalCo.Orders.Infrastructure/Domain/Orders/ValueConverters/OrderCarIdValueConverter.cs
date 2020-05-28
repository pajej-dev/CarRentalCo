using CarRentalCo.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders.ValueConverters
{
    public class OrderCarIdValueConverter : ValueConverter<OrderCarId, Guid>
    {
        public OrderCarIdValueConverter(ConverterMappingHints converterMappingHints = null)
            : base(
                    id => id.Id,
                    val => new OrderCarId(val), converterMappingHints
                  )
        { }
    }
}
