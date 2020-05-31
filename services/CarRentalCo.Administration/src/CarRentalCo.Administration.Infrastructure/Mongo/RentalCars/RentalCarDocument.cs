using CarRentalCo.Common.Infrastructure.Types;
using System;

namespace CarRentalCo.Administration.Infrastructure.Mongo.RentalCars
{
    public class RentalCarDocument : IIdentifiable
    {
        public Guid Id { get; set; }
        public RentalCarSpecificationDocument Specification { get;  set; }
        public RentalCarOperatingInfoDocument OperatingInfo { get;  set; }
        public string VinNumber { get;  set; }
        public string Description { get;  set; }
        public double PricePerDay { get;  set; }
        public string ImageUrl { get;  set; }
    }

    public class RentalCarOperatingInfoDocument
    {
        public DateTime TechnicalReviewValidThru { get; set; }
        public DateTime InsurrenceValidThru { get; set; }
        public DateTime OilValidThru { get; set; }
    }

    public class RentalCarSpecificationDocument
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public ColourDocument Colour { get; set; }
    }

    public enum ColourDocument
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
