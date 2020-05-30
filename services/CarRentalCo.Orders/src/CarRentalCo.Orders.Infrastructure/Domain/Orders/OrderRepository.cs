using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Domain.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext ordersContext;
        private readonly IConfiguration configuration;

        public OrderRepository(OrdersDbContext ordersContext, IConfiguration configuration)
        {
            this.ordersContext = ordersContext;
            this.configuration = configuration;
        }

        public async Task AddAsync(Order order)
        {
            await ordersContext.AddAsync(order);
            await ordersContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetByCustomerIdAsync(CustomerId customerId)
        {
            return await ordersContext.Orders.Include(x => x.OrderCars).Where(x => x.CustomerId == customerId).ToListAsync();
            //var order =  await ordersContext.Orders.IncludePaths("OrderCars").ToListAsync();
            
        }

        public async Task<Order> GetByIdAsync(OrderId orderId)
        {
            var connectionString = configuration.GetConnectionString("CarRentalCo");
             string query =
                @"SELECT TOP(100) Orders.[Id]
                  ,Orders.[CustomerId]
                  ,Orders.[TotalPrice]
                  ,Orders.[TotalDays]
                  ,Orders.[CreatedAt]
                  ,Orders.[OrderStatus]
                  ,Orders.[Version]
	              ,OrderCars.Id
	              ,OrderCars.PricePerDay
	              ,OrderCars.RentalCarId
	              ,OrderCars.RentalStartDate
	              ,OrderCars.RentalEndDate
              FROM [CarRentalCo].[orders].[Orders] 
              LEFT JOIN [orders].[OrderCars]  
              ON OrderCars.OrderId = Orders.Id" + orderId;


            using (var connection = new SqlConnection(connectionString))
            {
                var orderDictionary = new Dictionary<int, Order>();


                var list = connection.Query<Order, OrderCar, Order>(
                    query,
                    (order, orderCar) =>
                    {
                        Order orderEntry;

                        if (!orderDictionary.TryGetValue(order.OrderID, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderDetails = new List<OrderDetail>();
                            orderDictionary.Add(orderEntry.OrderID, orderEntry);
                        }

                        orderEntry.OrderDetails.Add(orderDetail);
                        return orderEntry;
                    },
                    splitOn: "OrderDetailID")
                .Distinct()
                .ToList();

            }
    }
}
