using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class OrderCarDto
    {
        public Guid Id { get;  set; }
        public Guid RentalCarId { get;  set; }
        public double PricePerDay { get;  set; }
        public DateTime RentalStartDate { get;  set; }
        public DateTime RentalEndDate { get;  set; }
    }
}
