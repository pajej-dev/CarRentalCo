using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Events
{
    public class CompanyCreatedDomainEvent : DomainEvent
    {
        public CompanyId CompanyId { get; }
        public OwnerId OwnerId { get; }

        public CompanyCreatedDomainEvent(CompanyId companyId, OwnerId ownerId)
        {
            CompanyId = companyId;
            OwnerId = ownerId;
        }

    }
}
