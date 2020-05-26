using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class RentalCarsInAgencyExceededException : DomainException
    {
        public override string Code => "rental_cars_in_agency_exceeded";
        public RentalCarsInAgencyExceededException(string message) : base(message)
        {
        }
    }
}
