using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Other;
using CarRentalCo.Orders.Domain.Customers.Events;
using System;

namespace CarRentalCo.Orders.Domain.Customers
{
    public class Customer : AggregateRoot, IEntity<CustomerId>
    {
        public CustomerId Id { get; private set; }

        private string fullName;
        private string email;
        private DateTime dateOfBirth;
        private DateTime creationDate;
        private DateTime? modificationDate;

        private Customer() { }

        private Customer(Guid id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            this.Id = new CustomerId(id);
            this.fullName = fullName;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.creationDate = creationDate;

            AddDomainEvent(new CustomerCreatedDomainEvent(Id));
        }

        public static Customer Create(Guid id, string fullName, string email, DateTime dateOfBirth)
        {
            return new Customer(id, fullName, email, dateOfBirth, SystemTime.UtcNow);
        }
    }
}
