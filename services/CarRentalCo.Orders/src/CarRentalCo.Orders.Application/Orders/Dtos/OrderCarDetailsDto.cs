using System;

namespace CarRentalCo.Orders.Application.Orders.Dtos
{
    public class OrderCarDetailsDto
    {
        //from db
        public Guid Id { get; set; }
        public Guid RentalCarId { get; set; }
        public double PricePerDay { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }

        //from administration
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public ColourDto Colour { get; set; }
        public string Description { get; set; }
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
