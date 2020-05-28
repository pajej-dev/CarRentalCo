using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Database;
using CarRentalCo.Orders.Infrastructure.Domain.Orders.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {

        public OrderEntityTypeConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(TableNames.Orders, TableSchemaNames.Orders);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasConversion(new OrderIdValueConverter());
            builder.Property(x => x.CustomerId).HasConversion(new CustomerIdValueConverter());
            builder.Property(x => x.TotalPrice).HasColumnName("TotalPrice");
            builder.Property<long>("totalDays").HasColumnName("TotalDays");
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(x => x.Version).HasColumnName("Version").IsConcurrencyToken();
            builder.Property(x => x.OrderStatus).HasColumnName("OrderStatus").HasConversion(x => x.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

            builder.OwnsMany(prop => prop.OrderCars, x => 
            {
                x.WithOwner().HasForeignKey("OrderId");
                x.ToTable(TableNames.OrderCars, TableSchemaNames.Orders);
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).HasColumnName("Id").HasConversion(new OrderCarIdValueConverter());
                x.Property(x => x.RentalCarId).HasColumnName("RentalCarId").HasConversion(new RentalCarIdValueConverter());
                x.Property(x => x.PricePerDay).HasColumnName("PricePerDay");
                x.Property(x => x.RentalStartDate).HasColumnName("RentalStartDate");
                x.Property(x => x.RentalEndDate).HasColumnName("RentalEndDate");
            });
        }
    }
}
