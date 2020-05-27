using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class RentalCarDto
    {
        public Guid Id { get; set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public ColourDto Colour { get; private set; }
        public DateTime TechnicalReviewValidThru { get; private set; }
        public DateTime InsurrenceValidThru { get; private set; }
        public DateTime OilValidThru { get; private set; }
        public string VinNumber { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum ColourDto
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black,
        Purple
    }

}
