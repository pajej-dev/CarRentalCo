using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.RentalCars.GetRentalCar
{
    public class GetRentalCarQueryHandler : IQueryHandler<GetRentalCarQuery, RentalCarDto>
    {
        private readonly IRentalCarsRepository rentalCarsRepository;

        public GetRentalCarQueryHandler(IRentalCarsRepository rentalCarsRepository)
        {
            this.rentalCarsRepository = rentalCarsRepository;
        }

        public async Task<RentalCarDto> HandleAsync(GetRentalCarQuery query)
        {
            var rentalCar = await rentalCarsRepository.GetByIdAsync(new RentalCarId(query.RentalCarId));

            //todo refactor to automamapper
            return rentalCar == default ? null :
                new RentalCarDto
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
}
