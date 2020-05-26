﻿using System.Threading.Tasks;

namespace CarRentalCo.Orders.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);

        Task<Customer> GetByIdAsync(CustomerId customerId);
    }
}
