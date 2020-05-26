using CarRentalCo.Common.Domain;

namespace CarRentalCo.Orders.Domain.Orders.Exceptions
{
    public class OrderTotalDaysExceededException : DomainException
    {
        public override string Code => "order_totalDays_exceeded";
        public OrderTotalDaysExceededException(string message) : base(message)
        {
        }
    }
}
