using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Infrastructure.Mongo.Companies;
using System.Linq;

namespace CarRentalCo.Administration.Infrastructure.Mappings
{
    public static class CompanyDocumentMappings
    {
        public static Company ToAggregate(this CompanyDocument companyDocument)
            => new Company(new CompanyId(companyDocument.Id), new OwnerId(companyDocument.OwnerId), companyDocument.Name,
                companyDocument.SetUpDate, CompanyContact.Create(companyDocument.CompanyContact.Email, companyDocument.CompanyContact.Phone),
                companyDocument.Agencies.Select(ag => ag.ToEntity()).ToList());

        public static Agency ToEntity(this AgencyDocument doc)
            => new Agency(new AgencyId(doc.Id),
                new AgencyAdress(doc.Adress.Street, doc.Adress.Number, doc.Adress.City, doc.Adress.PostalCode, doc.Adress.Country),
                (AgencyRole)doc.Role, doc.RoleAssignDate, doc.SetUpDate, doc.RentalCars.Select(x => new Domain.RentalCars.RentalCarId(x)).ToList());


        public static CompanyDocument ToDocument(this Company company)
            => new CompanyDocument
            {
                Id = company.Id.Value,
                CompanyContact = new CompanyContactDocument { Email = company.CompanyContact.Email, Phone = company.CompanyContact.Phone},
                Name = company.Name,
                OwnerId = company.OwnerId.Value,
                SetUpDate = company.SetUpDate,
                Agencies = company.Agencies.Select(x => x.ToDocument()).ToList()
            };

        public static AgencyAdressDocument ToDocument(this AgencyAdress ag)
             => new AgencyAdressDocument
             {
                 City = ag.City,
                 Country = ag.Country,
                 PostalCode = ag.PostalCode,
                 Number = ag.Number,
                 Street = ag.Street
             };

        public static AgencyDocument ToDocument(this Agency ag)
             => new AgencyDocument
             {
                 Id = ag.Id.Value,
                 Adress = ag.Adress.ToDocument(),
                 Role = (AgencyRoleDocument)ag.Role,
                 RoleAssignDate = ag.RoleAssignDate,
                 SetUpDate = ag.SetUpDate,
                 RentalCars = ag.RentalCars.Select(x => x.Value).ToList()
             };


    }
}
