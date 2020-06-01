using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class RentalCarDto
    {
        public Guid Id { get; set; }
        public double PricePerDay { get; set; }
    }
}
