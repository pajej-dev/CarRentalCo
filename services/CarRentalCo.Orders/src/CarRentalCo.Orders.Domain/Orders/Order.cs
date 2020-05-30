using CarRentalCo.Common.Domain;
using CarRentalCo.Orders.Domain.Orders.Events;
using CarRentalCo.Orders.Domain.Orders.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class Order : AggregateRoot, IEntity<OrderId>
    {
        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public IList<OrderCar> OrderCars { get; private set; }
        public double TotalPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public long TotalDays { get; private set; }

        private Order()
        {
            this.OrderCars = new List<OrderCar>();

        }

        private Order(OrderId id, CustomerId customerId, DateTime createdAt, OrderStatus orderStatus, IList<OrderCar> orderCars = null)
        {
            Id = id;
            CustomerId = customerId;
            this.OrderCars = orderCars ?? new List<OrderCar>();
            this.CreatedAt = createdAt;
            this.OrderStatus = orderStatus;
            this.CalculateTotalDays();
            this.CalculateTotalPrice();

            AddDomainEvent(new OrderCreatedDomainEvent(Id, customerId));
        }

        private void CalculateTotalPrice()
        {
            double price = 0;

            foreach (var item in OrderCars)
            {
                price += ((item.RentalEndDate - item.RentalStartDate).TotalDays * item.PricePerDay);
            }

            this.TotalPrice = price;
        }

        private void CalculateTotalDays()
        {
            long totalDays = 0;

            foreach (var item in OrderCars)
            {
                totalDays += (long)Math.Round(item.RentalEndDate.Subtract(item.RentalStartDate).TotalDays);
            }

            this.TotalDays = totalDays;
        }


        public static Order Create(OrderId id, CustomerId customerId, DateTime createdAt, IList<OrderCar> orderCars = null)
        {
            var groupedOrderCars = orderCars.GroupBy(x => x.RentalCarId);
            if (groupedOrderCars?.Any(x => x.Count() > 1) ?? false)
            {
                throw new OrderCannotContainsDuplicateRentalCarsException("Cannot create order with duplicate rental cars");
            }

            if(orderCars.Sum(x => (long)Math.Round(x.RentalEndDate.Subtract(x.RentalStartDate).TotalDays)) > 20)
            {
                throw new OrderTotalDaysExceededException("Order rental cannot be longer than 20 days");
            }

            return new Order(id, customerId, createdAt, OrderStatus.New, orderCars);
        }

        public void AddOrderCar(RentalCarId rentalCarId, double pricePerDay, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            if (OrderCars.Count == 3)
            {
                throw new OrderCannotContainsMoreThanThreeOrderCarsException("Order can contains only three OrderCars");
            }

            if (OrderCars?.Any(x => x.RentalCarId == rentalCarId) ?? false)
            {
                throw new OrderCannotContainsDuplicateRentalCarsException("Cannot create order with duplicate rental cars");
            }

            if (TotalDays + (long)Math.Round(rentalEndDate.Subtract(rentalStartDate).TotalDays) > 20)
            {
                throw new OrderTotalDaysExceededException("Order rental cannot be longer than 20 days");
            }

            OrderCars.Add(OrderCar.Create(null,rentalCarId, pricePerDay, rentalStartDate, rentalEndDate));
            AddDomainEvent(new OrderCarAddedDomainEvent(Id, rentalCarId, CustomerId));

            this.CalculateTotalDays();
            this.CalculateTotalPrice();
        }

        public void RemoveOrderCar(RentalCarId rentalCarId)
        {
            if (!OrderCars.Any(x => x.RentalCarId == rentalCarId))
            {
                throw new OrderCarNotFoundInOrderException("Cannot create order with duplicate rental cars");
            }

            var orderToRemove = OrderCars.First(x => x.RentalCarId == rentalCarId);
            OrderCars.Remove(orderToRemove);
            AddDomainEvent(new OrderCarRemovedDomainEvent(Id, rentalCarId, CustomerId));

            this.CalculateTotalDays();
            this.CalculateTotalPrice();
        }

        public void CancelOrder()
        {
            if (OrderStatus == OrderStatus.Canceled || OrderStatus == OrderStatus.Finished)
            {
                throw new CannotChangeOrderStatusException(Id, OrderStatus, OrderStatus.Canceled);
            }

            OrderStatus = OrderStatus.Canceled;
            AddDomainEvent(new OrderCanceledDomainEvent(Id, CustomerId));
        }

        public void FinishOrder()
        {
            if (OrderStatus == OrderStatus.Canceled || OrderStatus == OrderStatus.Finished)
            {
                throw new CannotChangeOrderStatusException(Id, OrderStatus, OrderStatus.Finished);
            }

            OrderStatus = OrderStatus.Finished;
            AddDomainEvent(new OrderFinishedDomainEvent(Id, CustomerId));
        }
    }
}
