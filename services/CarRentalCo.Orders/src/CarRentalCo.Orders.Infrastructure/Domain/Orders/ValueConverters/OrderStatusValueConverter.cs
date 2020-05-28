using CarRentalCo.Orders.Application.Orders.Dtos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders.ValueConverters
{
    public class OrderStatusValueConverter : ValueConverter<OrderStatus, string>
    {
        public OrderStatusValueConverter(ConverterMappingHints converterMappingHints = null)
            : base(
                    status => status.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v), converterMappingHints
                  )
        { }

    }
}
