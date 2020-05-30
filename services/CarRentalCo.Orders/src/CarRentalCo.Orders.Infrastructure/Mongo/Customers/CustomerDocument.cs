using CarRentalCo.Common.Infrastructure.Types;
using System;

namespace CarRentalCo.Orders.Infrastructure.Mongo.Customers
{
    public class CustomerDocument : IIdentifiable
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
