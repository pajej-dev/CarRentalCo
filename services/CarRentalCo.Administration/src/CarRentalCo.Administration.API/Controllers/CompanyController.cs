using CarRentalCo.Administration.API.Requests;
using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Application.Companies.Features.AddAgencyRentalCar;
using CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency;
using CarRentalCo.Administration.Application.Companies.Features.CreateCompany;
using CarRentalCo.Administration.Application.Companies.Features.GetCompany;
using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Common.Application.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CarRentalCo.Administration.API.Controllers
{
    [Route("administrationApi/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICommandHandler<CreateCompanyCommand> createCompanyHandler;
        private readonly ICommandHandler<AddCompanyAgencyCommand> addCompanyAgencyHandler;
        private readonly ICommandHandler<AddAgencyRentalCarCommand> addRentalCarHandler;
        private readonly IQueryHandler<GetCompanyQuery, CompanyDto> getCompanyHandler;

        public CompanyController(ICommandHandler<CreateCompanyCommand> createCompanyHandler,
            IQueryHandler<GetCompanyQuery, CompanyDto> getCompanyHandler,
            ICommandHandler<AddCompanyAgencyCommand> addCompanyAgencyHandler,
            ICommandHandler<AddAgencyRentalCarCommand> addRentalCarHandler)
        {
            this.createCompanyHandler = createCompanyHandler;
            this.getCompanyHandler = getCompanyHandler;
            this.addCompanyAgencyHandler = addCompanyAgencyHandler;
            this.addRentalCarHandler = addRentalCarHandler;
        }

        /// <summary>
        /// Get company by id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        /// <response code="404">If no company exists</response>
        [HttpGet]
        [Route("{companyId}")]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetCompany([FromRoute] Guid companyId)
        {
            var result = await getCompanyHandler.HandleAsync(new GetCompanyQuery { Id = new Domain.Companies.CompanyId(companyId) });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Add company
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddCompany([FromBody] CreateCompanyRequest request)
        {
            await createCompanyHandler.HandleAsync(new CreateCompanyCommand(new CompanyId(request.CompanyId),
                new Domain.Owners.OwnerId(request.OwnerId), request.Name, request.Email, request.Phone));

            return Ok(request.CompanyId);
        }

        /// <summary>
        /// Add company agency
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("agency")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddCompanyAgency([FromBody] AddCompanyAgencyRequest request)
        {
            await addCompanyAgencyHandler.HandleAsync(new AddCompanyAgencyCommand(new CompanyId(request.CompanyId), new AgencyId(request.AgencyId),
                new AddCompanyAgencyCommand.AddCompanyAgencyAdressModel(request.Street, request.Number, request.City, request.PostalCode, request.Country)));

            return Ok(request.CompanyId);
        }

        /// <summary>
        /// Add company agency
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Data</response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("agencyRentalCar")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddAgencyRentalCar([FromBody] AddAgencyRentalCarRequest request)
        {
            await addRentalCarHandler.HandleAsync(new AddAgencyRentalCarCommand(new CompanyId(request.CompanyId), new AgencyId(request.AgencyId),
                new Domain.RentalCars.RentalCarId(request.RentalCarId)));

            return Ok(request.CompanyId);
        }

    }
}