using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class RentalCarDto
    {
        public Guid Id { get; set; }
        public string Brand { get;  set; }
        public string Model { get;  set; }
        public DateTime ProductionDate { get;  set; }
        public ColourDto Colour { get;  set; }
        public DateTime TechnicalReviewValidThru { get;  set; }
        public DateTime InsurrenceValidThru { get;  set; }
        public DateTime OilValidThru { get;  set; }
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
