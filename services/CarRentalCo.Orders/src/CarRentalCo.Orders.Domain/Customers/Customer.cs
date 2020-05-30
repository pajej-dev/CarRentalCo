﻿using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Other;
using CarRentalCo.Orders.Domain.Customers.Events;
using System;

namespace CarRentalCo.Orders.Domain.Customers
{
    public class Customer : AggregateRoot, IEntity<CustomerId>
    {
        public CustomerId Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        private Customer() { }

        private Customer(CustomerId id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            this.Id =id;
            this.FullName = fullName;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
            this.CreationDate = creationDate;

            AddDomainEvent(new CustomerCreatedDomainEvent(Id));
        }

        public static Customer Create(CustomerId id, string fullName, string email, DateTime dateOfBirth)
        {
            return new Customer(id, fullName, email, dateOfBirth, SystemTime.UtcNow);
        }
    }
}
