using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Application.Companies.Extensions;
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

        public GetCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<CompanyDto> HandleAsync(GetCompanyQuery query)
        {
            var result = await companyRepository.GetByIdAsync(query.Id);

            return result == null ? default : result.AsDto();
        }
    }
}
