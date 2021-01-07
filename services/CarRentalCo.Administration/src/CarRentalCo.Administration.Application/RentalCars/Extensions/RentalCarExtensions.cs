using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Administration.Domain.RentalCars;

namespace CarRentalCo.Administration.Application.RentalCars.Extensions
{
    public static class RentalCarExtensions
    {
        public static RentalCarDto AsDto(this RentalCar rentalCar)
            => new RentalCarDto
            {
                Id = rentalCar.Id.Value,
                Description = rentalCar.Description,
                ImageUrl = rentalCar.ImageUrl,
                PricePerDay = rentalCar.PricePerDay,
                VinNumber = rentalCar.VinNumber,
                OperatingInfo = new RentalCarOperatingInfoDto
                {
                    InsurrenceValidThru = rentalCar.OperatingInfo.InsurrenceValidThru,
                    OilValidThru = rentalCar.OperatingInfo.OilValidThru,
                    TechnicalReviewValidThru = rentalCar.OperatingInfo.TechnicalReviewValidThru
                },
                Specification = new RentalCarSpecificationDto
                {
                    Brand = rentalCar.Specification.Brand,
                    Colour = (ColourDto)rentalCar.Specification.Colour,
                    Model = rentalCar.Specification.Model,
                    ProductionDate = rentalCar.Specification.ProductionDate
                }
            };
    }
}

