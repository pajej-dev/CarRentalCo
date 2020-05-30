using AutoMapper;
using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Mongo.Customers;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using System.Linq;
using CustomerId = CarRentalCo.Orders.Domain.Orders.CustomerId;

namespace CarRentalCo.Orders.Infrastructure.Mappings
{
    public static class MongoDocumentMappingExtensions
    {
        public static Order ToAggregate(this OrderDocument orderDocument)
            => Order.Create(new OrderId(orderDocument.Id), new CustomerId(orderDocument.CustomerId), orderDocument.CreatedAt,
                     orderDocument.OrderCars.Select(car => OrderCar.Create(new OrderCarId(car.Id), new RentalCarId(car.RentalCarId),
                        car.PricePerDay, car.RentalStartDate, car.RentalEndDate)).ToList());

        public static OrderDocument ToDocument(this Order order)
        => new OrderDocument
        {
            Id = order.Id.Value,
            CreatedAt = order.CreatedAt,
            CustomerId = order.CustomerId.Value,
            OrderStatus = (OrderStatusDocument)order.OrderStatus,
            TotalDays = order.TotalDays,
            TotalPrice = order.TotalPrice,
            OrderCars = order.OrderCars.Select(c => new OrderCarDocument
            {
                Id = c.Id.Value,
                PricePerDay = c.PricePerDay,
                RentalCarId = c.RentalCarId.Value,
                RentalEndDate = c.RentalEndDate,
                RentalStartDate = c.RentalStartDate
            }).ToList()
        };

        public static Customer ToAggregate(this CustomerDocument customerDocument)
            => Customer.Create(new Domain.Customers.CustomerId(customerDocument.Id), customerDocument.FullName, customerDocument.Email, customerDocument.DateOfBirth);

        public static CustomerDocument ToDocument(this Customer customer)
        => new CustomerDocument
        {
            Id = customer.Id.Value,
            CreationDate = customer.CreationDate,
            DateOfBirth = customer.DateOfBirth,
            Email = customer.Email,
            FullName = customer.FullName,
            ModificationDate = customer.ModificationDate
        };

    }

}
