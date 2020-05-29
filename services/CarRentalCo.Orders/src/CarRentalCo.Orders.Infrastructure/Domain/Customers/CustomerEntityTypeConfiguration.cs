using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CarRentalCo.Orders.Infrastructure.Domain.Customers
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(TableNames.Customers, TableSchemaNames.Orders);

            builder.Property(x => x.Id).HasColumnName("Id").HasConversion(new CustomerIdValueConverter());
            builder.HasKey(x => x.Id);
            builder.Property<string>("fullName").HasColumnName("FullName");
            builder.Property<string>("email").HasColumnName("Email");
            builder.Property<DateTime>("dateOfBirth").HasColumnName("DateOfBirth");
            builder.Property<DateTime>("creationDate").HasColumnName("CreationDate");
            builder.Property<DateTime?>("modificationDate").HasColumnName("ModificationDate").IsRequired(false);
            builder.Property(x => x.Version).HasColumnName("Version").IsConcurrencyToken();

        }

    }
}
