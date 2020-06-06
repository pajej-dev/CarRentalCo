using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.API.Requests;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.AddOrderCar;
using CarRentalCo.Orders.Application.Orders.Features.CreateOrder;
using CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders;
using CarRentalCo.Orders.Application.Orders.Features.GetOrder;
using CarRentalCo.Orders.Application.Orders.Features.GetOrders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.API.Controllers
{
    [Route("ordersApi/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IQueryHandler<GetOrdersQuery, PagedResult<OrderDto>> getOrdersQueryHandler;
        private readonly IQueryHandler<GetOrderQuery, OrderDto> getOrderQueryHandler;
        private readonly IQueryHandler<GetCustomerOrdersQuery, PagedResult<OrderDto>> getCustomerOrdersQuery;
        private readonly ICommandHandler<CreateOrderCommand> createOrderCommandHandler;
        private readonly ICommandHandler<AddOrderCarCommand> addOrderCarCommandHandler;

        public OrdersController(IQueryHandler<GetOrdersQuery,PagedResult<OrderDto>> getOrdersQueryHandler,
                IQueryHandler<GetOrderQuery, OrderDto> getOrderQueryHandler,
                IQueryHandler<GetCustomerOrdersQuery, PagedResult<OrderDto>> getCustomerOrdersQuery,
                ICommandHandler<CreateOrderCommand> createOrderCommandHandler,
                ICommandHandler<AddOrderCarCommand> addOrderCarCommandHandler
            )
        {
            this.getOrdersQueryHandler = getOrdersQueryHandler;
            this.getOrderQueryHandler = getOrderQueryHandler;
            this.getCustomerOrdersQuery = getCustomerOrdersQuery;
            this.createOrderCommandHandler = createOrderCommandHandler;
            this.addOrderCarCommandHandler = addOrderCarCommandHandler;
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        /// <response code="404">If no order exists</response>
        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        [ProducesResponseType(typeof(ICollection<OrderDto>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetOrders([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            var result = await getOrdersQueryHandler.HandleAsync(new GetOrdersQuery { PageNumber = pageNumber, PageSize = pageSize});

            if (result == null)
                return NotFound();

            return Ok(result);
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
        [Route("{orderId}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetOrder([FromRoute] Guid orderId)
        {
            var result = await getOrderQueryHandler.HandleAsync(new GetOrderQuery {OrderId = orderId });

            if (result == null)
                return NotFound();

            return Ok(result);
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
        [Route("customer/{customerId}")]
        [ProducesResponseType(typeof(ICollection<OrderDto>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetCustomerOrders([FromRoute] Guid customerId)
        {
            var result = await getCustomerOrdersQuery.HandleAsync(new GetCustomerOrdersQuery { CustomerId = customerId });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Add order
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Created an order</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest command)
        {
            //todo mapper
            await createOrderCommandHandler.HandleAsync(new CreateOrderCommand(command.OrderId, command.CustomerId,
                command.OrderCars.Select(x => new CreateOrderOrderCarModel(x.RentalCarId, x.RentalStartDate, x.RentalEndDate)).ToList()));

            return Ok(command.OrderId);
        }

        /// <summary>
        /// Add order car
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Added an order car</response>
        [HttpPost]
        [Route("orderCar")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddOrderCar([FromBody] AddOrderCarRequest command)
        {
            //todo mapper
            await addOrderCarCommandHandler.HandleAsync(new AddOrderCarCommand(command.OrderId, command.RentalCarId,
                command.RentalStartDate, command.RentalEndDate));

            return Ok();
        }

    }
}