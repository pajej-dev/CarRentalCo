using System;

namespace CarRentalCo.Administration.API.Requests
{
    public class CreateRentalCarRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public RentalCarSpecificationRequestModel Specification { get; set; }
        public RentalCarOperatingInfoModelRequestModel OperatingInfo { get; set; }
        public string VinNumber { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }
        public string ImageUrl { get; set; }
    }

    public class RentalCarOperatingInfoModelRequestModel
    {
        public DateTime TechnicalReviewValidThru { get; set; }
        public DateTime InsurrenceValidThru { get; set; }
        public DateTime OilValidThru { get; set; }
    }

    public class RentalCarSpecificationRequestModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public ColourRequestModel Colour { get; set; }
    }

    public enum ColourRequestModel
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
