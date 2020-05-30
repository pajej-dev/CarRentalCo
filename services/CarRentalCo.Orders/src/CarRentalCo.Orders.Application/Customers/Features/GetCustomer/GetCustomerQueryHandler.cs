using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Other;
using CarRentalCo.Orders.Application.Customers.Dtos;
using CarRentalCo.Orders.Application.Customers.Features.CreateCustomer;
using CarRentalCo.Orders.Domain.Customers;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Customers.Features.GetCustomer
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICommandHandler<CreateCustomerCommand> commandHandler;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository, ICommandHandler<CreateCustomerCommand> commandHandler)
        {
            this.customerRepository = customerRepository;
            this.commandHandler = commandHandler;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomerQuery query)
        { 
            var customer = await customerRepository.GetByIdAsync(new CustomerId(query.CustomerId));

            return customer == null ? default : 
                new CustomerDto 
                { 
                    Id = customer.Id.Value,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    DateOfBirth = customer.DateOfBirth,
                    CreationDate = customer.CreationDate
                };
        }
    }
}
