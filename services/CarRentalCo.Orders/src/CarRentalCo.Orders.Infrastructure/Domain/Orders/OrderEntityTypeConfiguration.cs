using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Database;
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

            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");
            builder.Property(x => x.TotalPrice).HasColumnName("TotalPrice");
            builder.Property<string>("totalDays").HasColumnName("TotalDays");
            builder.Property<DateTime>("createdAt").HasColumnName("CreatedAt");
            builder.Property<OrderStatus>("orderStatus").HasColumnName("OrderStatus")
                .HasConversion(v => v.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

            builder.OwnsMany(prop => prop.OrderCars, x => 
            {
                x.WithOwner().HasForeignKey("OrderId");
                x.ToTable(TableNames.OrderCars, TableSchemaNames.Orders);
                x.HasKey(x => x.Id);

                x.Property(x => x.RentalCarId).HasColumnName("RentalCarId");
                x.Property(x => x.PricePerDay).HasColumnName("PricePerDay");
                x.Property(x => x.RentalStartDate).HasColumnName("RentalStartDate");
                x.Property(x => x.RentalEndDate).HasColumnName("RentalEndDate");
            });
        }
    }
}
