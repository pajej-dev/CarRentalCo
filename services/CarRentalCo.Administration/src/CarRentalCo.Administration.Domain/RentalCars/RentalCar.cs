using CarRentalCo.Administration.Domain.RentalCars.Events;
using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public class RentalCar : AggregateRoot, IEntity<RentalCarId>
    {
        public RentalCarId Id { get; private set; }
        public RentalCarSpecification Specification { get; private set; }
        public RentalCarOperatingInfo OperatingInfo { get; private set; }
        public string VinNumber { get; private set; }
        public string Description { get; private set; }
        public double PricePerDay { get; private set; }
        public string ImageUrl { get; private set; }

        public RentalCar(RentalCarId id, RentalCarSpecification specification, RentalCarOperatingInfo operatingInfo, string vinNumber,
            string description, double pricePerDay, string imageUrl = null)
        {
            this.Id = id;
            this.Specification = specification;
            this.OperatingInfo = operatingInfo;
            this.VinNumber = vinNumber;
            this.Description = description;
            this.PricePerDay = pricePerDay;
            this.ImageUrl = imageUrl;
        }

        public static RentalCar Create(RentalCarId id, RentalCarSpecification specification, RentalCarOperatingInfo operatingInfo, string vinNumber,
            string description, double pricePerDay, string imageUrl = null)
        {
            var rentalCar = new RentalCar(id, specification, operatingInfo, vinNumber, description, pricePerDay, imageUrl);
            rentalCar.AddDomainEvent(new RentalCarCreatedDomainEvent(id));

            return rentalCar;
        }
    }
}