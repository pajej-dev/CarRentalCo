using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Administration.Application.RentalCars.Features.CreateRentalCar
{
    public class CreateRentalCarCommand : ICommand
    {
        public RentalCarId Id { get; private set; }
        public RentalCarSpecificationModel Specification { get; private set; }
        public RentalCarOperatingInfoModel OperatingInfo { get; private set; }
        public string VinNumber { get; private set; }
        public string Description { get; private set; }
        public double PricePerDay { get; private set; }
        public string ImageUrl { get; private set; }

        public CreateRentalCarCommand(RentalCarId id, RentalCarSpecificationModel specification, RentalCarOperatingInfoModel operatingInfo,
            string vinNumber, string description, double pricePerDay, string imageUrl)
        {
            Id = id;
            Specification = specification;
            OperatingInfo = operatingInfo;
            VinNumber = vinNumber;
            Description = description;
            PricePerDay = pricePerDay;
            ImageUrl = imageUrl;
        }

    }

    public class RentalCarOperatingInfoModel
    {
        public DateTime TechnicalReviewValidThru { get; private set; }
        public DateTime InsurrenceValidThru { get; private set; }
        public DateTime OilValidThru { get; private set; }

        public RentalCarOperatingInfoModel(DateTime technicalReviewValidThru, DateTime insurrenceValidThru, DateTime oilValidThru)
        {
            TechnicalReviewValidThru = technicalReviewValidThru;
            InsurrenceValidThru = insurrenceValidThru;
            OilValidThru = oilValidThru;
        }
    }

    public class RentalCarSpecificationModel
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public Colour Colour { get; private set; }

        public RentalCarSpecificationModel(string brand, string model, DateTime productionDate, Colour colour)
        {
            Brand = brand;
            Model = model;
            ProductionDate = productionDate;
            Colour = colour;
        }

    }


}
