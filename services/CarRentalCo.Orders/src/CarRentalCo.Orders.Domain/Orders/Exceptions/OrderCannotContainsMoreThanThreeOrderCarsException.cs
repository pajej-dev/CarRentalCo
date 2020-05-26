using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class OrderCannotContainsMoreThanThreeOrderCarsException : DomainException
    {
        public override string Code => "order_cannot_contains_more_than_three_orderCars_exception";
        public OrderCannotContainsMoreThanThreeOrderCarsException(string message) : base(message)
        {
        }
    }
}
