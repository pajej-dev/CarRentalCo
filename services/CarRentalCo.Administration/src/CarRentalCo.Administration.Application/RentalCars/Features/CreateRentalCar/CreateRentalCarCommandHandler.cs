using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.RentalCars.Features.CreateRentalCar
{
    public class CreateRentalCarCommandHandler : ICommandHandler<CreateRentalCarCommand>
    {
        private readonly IRentalCarsRepository rentalCarsRepository;

        public CreateRentalCarCommandHandler(IRentalCarsRepository rentalCarsRepository)
        {
            this.rentalCarsRepository = rentalCarsRepository;
        }

        public async Task HandleAsync(CreateRentalCarCommand command, Guid correlationId = default)
        {
            var specification = new RentalCarSpecification(command.Specification.Brand, command.Specification.Model,
                command.Specification.ProductionDate, (Colour)command.Specification.Colour);

            var operatingInfo = new RentalCarOperatingInfo(command.OperatingInfo.TechnicalReviewValidThru,
                command.OperatingInfo.InsurrenceValidThru, command.OperatingInfo.OilValidThru);

            var rentalCar = RentalCar.Create(command.Id, specification, operatingInfo, command.VinNumber, command.Description,
                command.PricePerDay, command.ImageUrl);

            await rentalCarsRepository.AddAsync(rentalCar);
        }
    }

}
