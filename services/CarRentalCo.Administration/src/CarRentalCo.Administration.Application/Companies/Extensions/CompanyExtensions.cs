using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Domain.Companies;
using System.Linq;
using CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency;
using static CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency.AddCompanyAgencyCommand;

namespace CarRentalCo.Administration.Application.Companies.Extensions
{
    public static class CompanyExtensions
    {
        public static AgencyAdressDto AsDto(this AgencyAdress agencyAdress)
            => new AgencyAdressDto
            {
                City = agencyAdress.City,
                Country = agencyAdress.Country,
                Number = agencyAdress.Number,
                PostalCode = agencyAdress.PostalCode,
                Street = agencyAdress.Street
            };

        public static AgencyDto AsDto(this Agency agency)
            => new AgencyDto
            {
                Adress = agency.Adress.AsDto(),
                Id = agency.Id.Value,
                Role = (AgencyRoleDto)agency.Role,
                SetUpDate = agency.SetUpDate,
                RoleAssignDate = agency.RoleAssignDate,
                RentalCars = agency.RentalCars.Select(x => x.Value).ToList()
            };

        public static CompanyContactDto AsDto(this CompanyContact companyContact)
            => new CompanyContactDto
            {
                Email = companyContact.Email,
                Phone = companyContact.Phone
            };

        public static CompanyDto AsDto(this Company company)
            => new CompanyDto
            {
                Id = company.Id.Value,
                Name = company.Name,
                OwnerId = company.OwnerId.Value,
                SetUpDate = company.SetUpDate,
                CompanyContact = company.CompanyContact.AsDto(),
                Agencies = company.Agencies.Select(x => x.AsDto()).ToList()
            };

        public static AgencyAdress AsValueObject(this AddCompanyAgencyAdressModel agencyAdressModel)
            => AgencyAdress.Create(agencyAdressModel.Street, agencyAdressModel.Number, agencyAdressModel.City,
                agencyAdressModel.PostalCode, agencyAdressModel.Country);
    }
}
