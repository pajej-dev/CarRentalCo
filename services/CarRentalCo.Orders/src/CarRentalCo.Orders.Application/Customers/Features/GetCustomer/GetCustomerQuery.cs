using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Orders.Application.Customers.Dtos;
using System;

namespace CarRentalCo.Orders.Application.Customers.Features.GetCustomer
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; set; }
    }
}
