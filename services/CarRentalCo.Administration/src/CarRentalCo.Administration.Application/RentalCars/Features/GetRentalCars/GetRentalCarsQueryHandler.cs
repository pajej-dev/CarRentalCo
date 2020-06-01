using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Common.Application.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars
{
    public class GetRentalCarsQueryHandler : IQueryHandler<GetRentalCarsQuery, ICollection<RentalCarDto>>
    {
        private readonly IGetRentalCarsService getRentalCarsService;

        public GetRentalCarsQueryHandler(IGetRentalCarsService getRentalCarsService)
        {
            this.getRentalCarsService = getRentalCarsService;
        }

        public async Task<ICollection<RentalCarDto>> HandleAsync(GetRentalCarsQuery query)
        {
            var rentalCars = await getRentalCarsService.GetAsync(query.RentalCarIds);

            return rentalCars;
        }
    }
}
