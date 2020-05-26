using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class RentalCarAlreadyAddedException : DomainException
    {
        public override string Code => "rentalCar_already_added";
        public RentalCarAlreadyAddedException(string message) : base(message)
        {
        }
    }
}
