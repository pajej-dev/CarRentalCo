using System;
using System.Collections.Generic;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public IList<OrderCarDto> OrderCars { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        New = 1,
        Finished = 2,
        Canceled = 3
    }
}
