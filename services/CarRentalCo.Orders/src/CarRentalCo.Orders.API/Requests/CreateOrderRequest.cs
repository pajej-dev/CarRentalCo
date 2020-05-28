using System;
using System.Collections.Generic;

namespace CarRentalCo.Orders.API.Requests
{
    public class CreateOrderRequest
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<CreateOrderOrderCarRequest> OrderCars { get; set; }

    }

    public class CreateOrderOrderCarRequest
    {
        public Guid RentalCarId { get;  set; }
        public DateTime RentalStartDate { get;  set; }
        public DateTime RentalEndDate { get;  set; }
    }

}
