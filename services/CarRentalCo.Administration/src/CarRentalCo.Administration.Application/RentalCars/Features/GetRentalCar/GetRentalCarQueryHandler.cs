using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Administration.Application.RentalCars.Extensions;
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

            return rentalCar == default ? null : rentalCar.AsDto();
        }
    }
}
