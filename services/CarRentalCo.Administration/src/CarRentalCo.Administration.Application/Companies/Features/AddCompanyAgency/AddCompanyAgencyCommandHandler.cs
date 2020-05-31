using AutoMapper;
using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Common.Application.Handlers;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency
{
    public class AddCompanyAgencyCommandHandler : ICommandHandler<AddCompanyAgencyCommand>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public AddCompanyAgencyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task HandleAsync(AddCompanyAgencyCommand command, Guid correlationId = default)
        {
            bool companyExists = await companyRepository.ExistsAsync(command.CompanyId);
            if (!companyExists)
            {
                throw new Exception("Unable to add agency. CompanyId not found");
            }

            var company = await companyRepository.GetByIdAsync(command.CompanyId);

            var agencyAdress = mapper.Map<AgencyAdress>(command.Adress);
            company.AddCompanyAgency(command.AgencyId, agencyAdress);
            await companyRepository.UpdateAsync(company);
        }
    }
}
