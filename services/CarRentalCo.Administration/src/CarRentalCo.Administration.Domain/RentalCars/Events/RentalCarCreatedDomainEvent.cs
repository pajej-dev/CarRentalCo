using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.RentalCars.Events
{
    public class RentalCarCreatedDomainEvent : DomainEvent
    {
        public RentalCarCreatedDomainEvent(RentalCarId rentalCarId)
        {
        }
    }
}
