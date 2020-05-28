using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCo.Orders.Infrastructure.Database
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCar> OrderCars { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
        }
    }
}
