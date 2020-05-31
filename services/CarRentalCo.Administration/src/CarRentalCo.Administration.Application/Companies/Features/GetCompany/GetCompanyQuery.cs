using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Common.Application.Contracts;

namespace CarRentalCo.Administration.Application.Companies.Features.GetCompany
{
    public class GetCompanyQuery : IQuery<CompanyDto>
    {
        public CompanyId Id { get; set; }
    }
}
