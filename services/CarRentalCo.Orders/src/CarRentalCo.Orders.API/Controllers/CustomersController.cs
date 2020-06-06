using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Orders.Application.Customers.Dtos;
using CarRentalCo.Orders.Application.Customers.Features.GetCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.API.Controllers
{
    [Route("ordersApi/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IQueryHandler<GetCustomerQuery, CustomerDto> getCustomerQueryHandler;

        public CustomersController(IQueryHandler<GetCustomerQuery, CustomerDto> getCustomerQueryHandler)
        {
            this.getCustomerQueryHandler = getCustomerQueryHandler;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        /// <response code="404">If no order exists</response>
        [HttpGet]
        [Route("{customerId}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetOrder([FromRoute] Guid customerId)
        {
            var result = await getCustomerQueryHandler.HandleAsync(new GetCustomerQuery { CustomerId = customerId });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}