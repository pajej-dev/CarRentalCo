using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class RentalCarSpecificationDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public ColourDto Colour { get; set; }

    }

}
