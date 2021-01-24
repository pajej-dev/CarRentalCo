using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Events
{
    public class CompanyHeadquarterChangedEvent : DomainEvent
    {
        public AgencyId InitialHeadquarterId { get; }
        public AgencyId NewHeadquarterId { get; }
        public CompanyId CompanyId { get; }

        public CompanyHeadquarterChangedEvent(AgencyId initialHeadquarterId, AgencyId newHeadquarterId, CompanyId companyId)
        {
            InitialHeadquarterId = initialHeadquarterId;
            NewHeadquarterId = newHeadquarterId;
            CompanyId = companyId;
        }
    }
}
