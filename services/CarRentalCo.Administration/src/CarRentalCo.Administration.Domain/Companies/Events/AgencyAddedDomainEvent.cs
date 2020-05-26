using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Events
{
    public class AgencyAddedDomainEvent : DomainEvent
    {
        public AgencyId AgencyId { get; }
        public CompanyId CompanyId { get; }

        public AgencyAddedDomainEvent(AgencyId agencyId, CompanyId companyId)
        {
            AgencyId = agencyId;
            CompanyId = companyId;
        }
    }
}
