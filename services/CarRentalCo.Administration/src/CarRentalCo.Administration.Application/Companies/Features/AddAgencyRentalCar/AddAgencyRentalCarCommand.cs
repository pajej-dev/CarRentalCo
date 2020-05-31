using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Contracts;

namespace CarRentalCo.Administration.Application.Companies.Features.AddAgencyRentalCar
{
    public class AddAgencyRentalCarCommand : ICommand
    {
        public CompanyId CompanyId { get; private set; }
        public AgencyId AgencyId { get; private set; }
        public RentalCarId RentalCarId { get; private set; }

        public AddAgencyRentalCarCommand(CompanyId companyId, AgencyId agencyId, RentalCarId rentalCarId)
        {
            CompanyId = companyId;
            AgencyId = agencyId;
            RentalCarId = rentalCarId;
        }

    }
}
