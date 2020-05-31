using AutoMapper;
using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Application.Owners.Features.CreateOwner;
using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Other;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.Companies.Features.GetCompany
{
    public class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public GetCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<CompanyDto> HandleAsync(GetCompanyQuery query)
        {
            var result = await companyRepository.GetByIdAsync(query.Id);

            return result == null ? default : mapper.Map<CompanyDto>(result);
        }
    }
}
