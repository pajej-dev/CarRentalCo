using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Events
{
    public class AgencyRentalCarAddedDomainEvent : DomainEvent
    {
        public AgencyId AgencyId { get; }
        public CompanyId CompanyId { get; }
        public RentalCarId RentalCarId { get; }

        public AgencyRentalCarAddedDomainEvent(AgencyId agencyId, CompanyId companyId, RentalCarId rentalCarId)
        {
            AgencyId = agencyId;
            CompanyId = companyId;
            RentalCarId = rentalCarId;
        }
    }
}
