using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Owners.Events
{
    public class OwnerCreatedDomainEvent : DomainEvent
    {
        public OwnerId OwnerId { get; }

        public OwnerCreatedDomainEvent(OwnerId ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
