using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class OrderCarRentalTooShortException : DomainException
    {
        public override string Code => "orderCar_rental_too_short_exception";
        public OrderCarRentalTooShortException(string message) : base(message)
        {
        }
    }
}
