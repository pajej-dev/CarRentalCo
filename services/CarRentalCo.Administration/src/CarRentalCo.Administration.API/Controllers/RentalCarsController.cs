using CarRentalCo.Administration.API.Requests;
using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Administration.Application.RentalCars.Features.CreateRentalCar;
using CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars;
using CarRentalCo.Administration.Application.RentalCars.GetRentalCar;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCarsController : ControllerBase
    {
        private readonly ICommandHandler<CreateRentalCarCommand> createRentalCarHandler;
        private readonly IQueryHandler<GetRentalCarQuery, RentalCarDto> getRentalCarHandler;
        private readonly IQueryHandler<GetRentalCarsQuery, ICollection<RentalCarDto>> getRentalCarsHandler;

        public RentalCarsController(ICommandHandler<CreateRentalCarCommand> createRentalCarHandler,
             IQueryHandler<GetRentalCarQuery, RentalCarDto> getRentalCarHandler,
             IQueryHandler<GetRentalCarsQuery, ICollection<RentalCarDto>> getRentalCarsHandler)
        {
            this.createRentalCarHandler = createRentalCarHandler;
            this.getRentalCarHandler = getRentalCarHandler;
            this.getRentalCarsHandler = getRentalCarsHandler;
        }

        /// <summary>
        /// Add rental car
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddRentalCar([FromBody] CreateRentalCarRequest request)
        {
            //todo map
            var operatingInfo = new RentalCarOperatingInfoModel(request.OperatingInfo.TechnicalReviewValidThru,
                request.OperatingInfo.InsurrenceValidThru, request.OperatingInfo.OilValidThru);

            var specification = new RentalCarSpecificationModel(request.Specification.Brand, request.Specification.Model,
                request.Specification.ProductionDate, (Colour)request.Specification.Colour);

            var command = new CreateRentalCarCommand(new RentalCarId(request.Id), specification, operatingInfo, request.VinNumber, request.Description,
                request.PricePerDay, request.ImageUrl);

            await createRentalCarHandler.HandleAsync(command);

            return Ok(request.Id);
        }

        /// <summary>
        /// Get rental car
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpGet]
        [Route("{rentalCarId}")]
        [ProducesResponseType(typeof(RentalCarDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRentalCar([FromRoute] Guid rentalCarId)
        {
            var result = await getRentalCarHandler.HandleAsync(new GetRentalCarQuery { RentalCarId = rentalCarId });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Get rental cars by Identifiers
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpGet]
        [ProducesResponseType(typeof(RentalCarDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRentalCars([FromBody] GetRentalCarsQuery request)
        {
            var result = await getRentalCarsHandler.HandleAsync(request);

            if (result == null || result.Count == 0)
                return NotFound();

            return Ok(result);
        }



    }
}
