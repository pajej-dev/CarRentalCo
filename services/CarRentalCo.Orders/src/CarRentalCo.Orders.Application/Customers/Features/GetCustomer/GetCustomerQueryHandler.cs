using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Customers.Dtos;
using CarRentalCo.Orders.Domain.Customers;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Application.Customers.Features.GetCustomer
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomerQuery query)
        {
            var customer = await customerRepository.GetByIdAsync(new CustomerId(query.CustomerId));

            return customer == null ? default : new CustomerDto { Id = customer.Id.Value };
        }
    }
}
