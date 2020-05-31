using CarRentalCo.Administration.API.Requests;
using CarRentalCo.Administration.Application.RentalCars.CreateRentalCar;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCarsController : ControllerBase
    {
        private readonly ICommandHandler<CreateRentalCarCommand> createRentalCarHandler;

        public RentalCarsController(ICommandHandler<CreateRentalCarCommand> createRentalCarHandler)
        {
            this.createRentalCarHandler = createRentalCarHandler;
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


    }
}
