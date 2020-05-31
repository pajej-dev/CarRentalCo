using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency
{
    public class AddCompanyAgencyCommand : ICommand
    {
        public CompanyId CompanyId { get; private set; }
        public AgencyId AgencyId { get; private set; }
        public AddCompanyAgencyAdressModel Adress { get; private set; }

        public AddCompanyAgencyCommand(CompanyId companyId, AgencyId agencyId, AddCompanyAgencyAdressModel adress)
        {
            CompanyId = companyId;
            AgencyId = agencyId;
            Adress = adress;
        }

        public class AddCompanyAgencyAdressModel
        {

            public string Street { get; private set; }
            public int Number { get; private set; }
            public string City { get; private set; }
            public string PostalCode { get; private set; }
            public string Country { get; private set; }
            public AddCompanyAgencyAdressModel(string street, int number, string city, string postalCode, string country)
            {
                Street = street;
                Number = number;
                City = city;
                PostalCode = postalCode;
                Country = country;
            }


        }
    }
}
