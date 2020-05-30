using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Orders.Domain.Customers;
using System;

namespace CarRentalCo.Orders.Application.Customers.Features.CreateCustomer
{
    public class CreateCustomerCommand : ICommand
    {
        public CustomerId Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public CreateCustomerCommand(CustomerId id, string fullName, string email, DateTime dateOfBirth)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

    }
}
