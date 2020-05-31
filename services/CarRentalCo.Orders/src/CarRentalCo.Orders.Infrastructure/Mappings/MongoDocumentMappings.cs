using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Mongo.Customers;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using System.Linq;
using CustomerId = CarRentalCo.Orders.Domain.Orders.CustomerId;
using OrderStatus = CarRentalCo.Orders.Domain.Orders.OrderStatus;

namespace CarRentalCo.Orders.Infrastructure.Mappings
{
    public static class MongoDocumentMappings
    {
        public static Order ToAggregate(this OrderDocument orderDocument)
            => new Order(new OrderId(orderDocument.Id), new CustomerId(orderDocument.CustomerId), orderDocument.CreatedAt, (OrderStatus)orderDocument.OrderStatus,
                     orderDocument.OrderCars.Select(car => new OrderCar(new OrderCarId(car.Id), new RentalCarId(car.RentalCarId),
                        car.PricePerDay, car.RentalStartDate, car.RentalEndDate)).ToList());

        public static OrderDto ToDto(this OrderDocument orderDocument)
            => new OrderDto
            {
                Id = orderDocument.Id,
                CreatedAt = orderDocument.CreatedAt,
                CustomerId = orderDocument.CustomerId,
                OrderCars = orderDocument.OrderCars.Select(z => new OrderCarDto
                {
                    Id = z.Id,
                    PricePerDay = z.PricePerDay,
                    RentalCarId = z.RentalCarId,
                    RentalEndDate = z.RentalEndDate,
                    RentalStartDate = z.RentalStartDate
                }).ToList(),
                OrderStatus = (Application.Orders.Dtos.OrderStatus)orderDocument.OrderStatus,
                TotalPrice = orderDocument.TotalPrice
            };

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
            => new Customer(new Domain.Customers.CustomerId(customerDocument.Id), customerDocument.FullName,
                   customerDocument.Email, customerDocument.DateOfBirth, customerDocument.CreationDate);

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
