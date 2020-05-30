using CarRentalCo.Common.Infrastructure.Types;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Orders
{
    public class OrderDocument : IIdentifiable
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public IList<OrderCarDocument> OrderCars { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatusDocument OrderStatus { get; set; }
        public long TotalDays { get; set; }

    }

    public class OrderCarDocument
    {
        public Guid Id { get; set; }
        public Guid RentalCarId { get; set; }
        public double PricePerDay { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }

    }

    public enum OrderStatusDocument
    {
        New = 1,
        Finished = 2,
        Canceled = 3
    }
}
