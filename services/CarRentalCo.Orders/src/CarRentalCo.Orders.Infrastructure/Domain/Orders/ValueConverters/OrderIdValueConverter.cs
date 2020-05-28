using CarRentalCo.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders
{
    public class OrderIdValueConverter : ValueConverter<OrderId, Guid>
    {
        public OrderIdValueConverter(ConverterMappingHints converterMappingHints = null)
            : base(
                    id => id.Value,
                    val => new OrderId(val), converterMappingHints
                  )
        { }
    }
}
