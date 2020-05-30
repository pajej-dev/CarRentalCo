using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Customers.Features.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task HandleAsync(CreateCustomerCommand command, Guid correlationId = default)
        {

            var customer = Customer.Create(command.Id, command.FullName, command.Email, command.DateOfBirth);
            await customerRepository.AddAsync(customer);
        }
    }
}
