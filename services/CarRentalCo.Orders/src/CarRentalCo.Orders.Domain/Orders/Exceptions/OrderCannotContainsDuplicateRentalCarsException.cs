using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class OrderCannotContainsDuplicateRentalCarsException : DomainException
    {
        public override string Code => "order_cannot_contains_duplicate_rentalCars";
        public OrderCannotContainsDuplicateRentalCarsException(string message) : base(message)
        {
        }
    }
}
