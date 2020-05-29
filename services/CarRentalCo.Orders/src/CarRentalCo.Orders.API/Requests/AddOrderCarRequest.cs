using System;

namespace CarRentalCo.Orders.API.Requests
{
    public class AddOrderCarRequest
    {
        public Guid OrderId { get;  set; }
        public Guid RentalCarId { get;  set; }
        public DateTime RentalStartDate { get;  set; }
        public DateTime RentalEndDate { get;  set; }
    }
}
