using AutoMapper;
using CarRentalCo.Orders.Domain.Customers;
using CarRentalCo.Orders.Domain.Orders;
using CarRentalCo.Orders.Infrastructure.Mongo.Customers;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using System.Linq;
using CustomerId = CarRentalCo.Orders.Domain.Orders.CustomerId;

namespace CarRentalCo.Orders.Infrastructure.Profiles
{
    public class MongoDocumentsProfle : Profile
    {
        public MongoDocumentsProfle()
        {
            //Order
            CreateMap<Order, OrderDocument>();
            CreateMap<OrderDocument, Order>().ConstructUsing(doc
                 => Order.Create(new OrderId(doc.Id), new CustomerId(doc.CustomerId), doc.CreatedAt,
                     doc.OrderCars.Select(car => OrderCar.Create(new RentalCarId(car.RentalCarId), car.PricePerDay, car.RentalStartDate, car.RentalEndDate)).ToList()));

            //Customer
            CreateMap<Customer, CustomerDocument>();
            CreateMap<CustomerDocument, Customer>().ConstructUsing(doc
                => Customer.Create(new Domain.Customers.CustomerId(doc.Id), doc.FullName, doc.Email, doc.CreationDate));
        }
    }
}
