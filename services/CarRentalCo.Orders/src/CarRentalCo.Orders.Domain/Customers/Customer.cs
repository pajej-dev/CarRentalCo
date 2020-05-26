using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Orders.Domain.Customers
{
    public class Customer : AggregateRoot, IEntity<CustomerId>
    {
        public CustomerId Id { get; private set; }

        private string fullName;
        private string email;
        private DateTime DateOfBirth;
        private DateTime CreationDate;
        private DateTime ModificationDate;

        private Customer() { }

        private Customer(Guid id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            this.Id = new CustomerId(id);
            this.fullName = fullName;
            this.email = email;
            this.DateOfBirth = dateOfBirth;
            this.CreationDate = creationDate;

            //todo domain event
        }

        public static Customer Create(Guid id, string fullName, string email, DateTime dateOfBirth, IDateTimeProvider dateTimeProvider)
        {
            return new Customer(id, fullName, email, dateOfBirth, dateTimeProvider.UtcNow);
        }
    }
}
