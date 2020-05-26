using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Domain;
using CarRentalCo.Orders.Domain.Orders.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalCo.Orders.Domain.Orders
{
    public class Order : AggregateRoot, IEntity<OrderId>
    {
        public OrderId Id { get; private set; }
        public int MyProperty { get; set; }
        public double TotalPrice => totalPrice;

        private IList<OrderCar> orderCars;
        private double totalPrice;
        private double totalDays;
        private DateTime createdAt;
        private OrderStatus orderStatus;

        private Order()
        {
        }

        private Order(OrderId id, DateTime createdAt, OrderStatus orderStatus, IList<OrderCar> orderCars = null)
        {
            Id = id;
            this.orderCars = orderCars ?? new List<OrderCar>();
            this.createdAt = createdAt;
            this.orderStatus = orderStatus;
            this.CalculateTotalDays();
            this.CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            double price = 0;

            foreach (var item in orderCars)
            {
                price += ((item.RentalEndDate - item.RentalStartDate).TotalDays * item.PricePerDay);
            }

            this.totalPrice = price;
        }

        private void CalculateTotalDays()
        {
            double totalDays = 0;

            foreach (var item in orderCars)
            {
                totalDays += (item.RentalEndDate - item.RentalStartDate).TotalDays;
            }

            this.totalDays = totalDays;
        }


        public static Order Create(OrderId id, DateTime createdAt, IList<OrderCar> orderCars = null)
        {
            var groupedOrderCars = orderCars.GroupBy(x => x.RentalCarId);
            if (groupedOrderCars?.Any(x => x.Count() > 1) ?? false)
            {
                throw new OrderCannotContainsDuplicateRentalCarsException("Cannot create order with duplicate rental cars");
            }

            return new Order(id, createdAt, OrderStatus.New, orderCars);
        }

        public void AddOrderCar(RentalCarId rentalCarId, double pricePerDay, DateTime rentalStartDate, DateTime rentalEndDate)
        {
            if (orderCars.Count == 3)
            {
                throw new OrderCannotContainsMoreThanThreeOrderCarsException("Order can contains only three OrderCars");
            }


            if (totalDays + (rentalEndDate - rentalStartDate).TotalDays > 20)
            {
                throw new OrderTotalDaysExceededException("Order rental cannot be longer than 20 days");
            }

            orderCars.Add(OrderCar.Create(rentalCarId, pricePerDay, rentalStartDate, rentalEndDate));

            this.CalculateTotalDays();
            this.CalculateTotalPrice();
        }

        public void RemoveOrderCar(RentalCarId rentalCarId)
        {
            if (!orderCars.Any(x => x.RentalCarId == rentalCarId))
            {
                throw new OrderCarNotFoundInOrderException("Cannot create order with duplicate rental cars");
            }

            var orderToRemove = orderCars.First(x => x.RentalCarId == rentalCarId);
            orderCars.Remove(orderToRemove);

            this.CalculateTotalDays();
            this.CalculateTotalPrice();
        }

        public void CancelOrder()
        {
            if (orderStatus == OrderStatus.Canceled || orderStatus == OrderStatus.Finished)
            {
                throw new CannotChangeOrderStatusException(Id, orderStatus, OrderStatus.Canceled);
            }
        }

        public void FinishOrder()
        {
            if (orderStatus == OrderStatus.Canceled || orderStatus == OrderStatus.Finished)
            {
                throw new CannotChangeOrderStatusException(Id, orderStatus, OrderStatus.Finished);
            }
        }
    }
}
