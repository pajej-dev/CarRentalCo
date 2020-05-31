using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.Companies.Features.AddAgencyRentalCar
{
    public class AddAgencyRentalCarCommandHandler : ICommandHandler<AddAgencyRentalCarCommand>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IRentalCarsRepository rentalCarsRepository;

        public AddAgencyRentalCarCommandHandler(ICompanyRepository companyRepository, IRentalCarsRepository rentalCarsRepository)
        {
            this.companyRepository = companyRepository;
            this.rentalCarsRepository = rentalCarsRepository;
        }

        public async Task HandleAsync(AddAgencyRentalCarCommand command, Guid correlationId = default)
        {
            var company = await companyRepository.GetByIdAsync(command.CompanyId);
            if (company == null)
            {
                throw new Exception("Cannot Add RentalCar to Agency. Company with provided CompanyId not exists");
            }

            var rentalCar = await rentalCarsRepository.GetByIdAsync(command.RentalCarId);
            if (rentalCar == null)
            {
                throw new Exception("Cannot Add RentalCar to Agency. RentalCar with provided RentalCarId not exists");
            }

            company.AddAgencyRentalCar(command.AgencyId, command.RentalCarId);
            await companyRepository.UpdateAsync(company);
        }
    }
}
