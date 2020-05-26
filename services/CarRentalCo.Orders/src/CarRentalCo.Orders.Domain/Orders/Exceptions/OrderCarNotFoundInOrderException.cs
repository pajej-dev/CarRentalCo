using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class OrderCarNotFoundInOrderException : DomainException
    {
        public override string Code => "orderCar_not_found_in_order_exception";
        public OrderCarNotFoundInOrderException(string message) : base(message)
        {
        }
    }
}
