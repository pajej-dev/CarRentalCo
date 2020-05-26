using CarRentalCo.Administration.Domain.RentalCars.Events;
using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public class RentalCar : AggregateRoot, IEntity<RentalCarId>
    {
        public RentalCarId Id { get; set; }

        private RentalCarSpecification specification;
        private RentalCarOperatingInfo operatingInfo;
        private string vinNumber;
        private string description;
        private double pricePerDay;
        private string imageUrl;

        private RentalCar()
        {
        }

        private RentalCar(RentalCarId id, RentalCarSpecification specification, RentalCarOperatingInfo operatingInfo, string vinNumber,
            string description, double pricePerDay, string imageUrl = null)
        {
            this.Id = id;
            this.specification = specification;
            this.operatingInfo = operatingInfo;
            this.vinNumber = vinNumber;
            this.description = description;
            this.pricePerDay = pricePerDay;
            this.imageUrl = imageUrl;

            AddDomainEvent(new RentalCarCreatedDomainEvent(Id));
        }

        public static RentalCar Create(RentalCarId id, RentalCarSpecification specification, RentalCarOperatingInfo operatingInfo, string vinNumber,
            string description, double pricePerDay, string imageUrl = null)
        {

            return new RentalCar(id, specification, operatingInfo, vinNumber, description, pricePerDay, imageUrl);
        }
    }
}