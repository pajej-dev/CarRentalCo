using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class RentalCarDto
    {
        public Guid Id { get; set; }
        public RentalCarSpecificationDto Specification { get; set; }
        public double PricePerDay { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
