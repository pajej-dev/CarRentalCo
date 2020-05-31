using CarRentalCo.Administration.Domain.Companies.Events;
using CarRentalCo.Administration.Domain.Companies.Exceptions;
using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalCo.Administration.Domain.Companies
{
    public class Company : AggregateRoot, IEntity<CompanyId>
    {
        public CompanyId Id { get; private set; }
        public OwnerId OwnerId { get; private set; }
        public IList<Agency> Agencies { get; private set; }
        public string Name { get; private set; }
        public DateTime SetUpDate { get; private set; }
        public CompanyContact CompanyContact { get; private set; }

        public Company(CompanyId id, OwnerId ownerId, string name, DateTime setUpDate, CompanyContact companyContact, IList<Agency> agencies = null)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.SetUpDate = setUpDate;
            this.CompanyContact = companyContact;
            this.Name = name;
            this.Agencies = agencies ?? new List<Agency>();
        }

        public static Company Create(CompanyId id, OwnerId ownerId, string name, DateTime setUpDate, CompanyContact companyContact)
        {
            var company = new Company(id, ownerId, name, setUpDate, companyContact);
            company.AddDomainEvent(new CompanyCreatedDomainEvent(id, ownerId));

            return company;
        }

        public void AddCompanyAgency(AgencyId agencyId, AgencyAdress adress)
        {
            if (Agencies.Count == 10)
                throw new AddCompanyAgencyRejectedException("Company cannot contains more than 10 Agencies");

            AgencyRole role;

            if (Agencies.Count == 0)
                role = AgencyRole.Headquarter;
            else
                role = AgencyRole.Standard;

            Agencies.Add(Agency.Create(agencyId,adress, role));
            AddDomainEvent(new AgencyAddedDomainEvent(agencyId, Id));
        }

        public void ChangeContact(CompanyContact companyContact)
        {
            this.CompanyContact = companyContact;
        }

        public void ChangeCompanyHeadquarter(AgencyId newHeadquarterId)
        {
            if (Agencies.Count == 0)
                throw new ChangeCompanyHeadquarterRejectedException("Company headquarter cannot be changed. Company does not contain any agency");

            var currentHQ = Agencies.First(x => x.Role == AgencyRole.Headquarter);
            currentHQ.ChangeRoleToStandard();

            var newHQ = Agencies.FirstOrDefault(x => x.Id == newHeadquarterId);
            if (newHQ == null)
                throw new ChangeCompanyHeadquarterRejectedException($"Company headquarter cannot be changed. " +
                    $"Provided '{nameof(AgencyId)}': {newHeadquarterId} not exists in a company");

            newHQ.ChangeRoleToHeadquarter();
        }

        public void AddAgencyRentalCar(AgencyId agencyId, RentalCarId rentalCarId)
        {
            var agency = Agencies.FirstOrDefault(x => x.Id == agencyId);

            if (agency == null)
                throw new AgencyNotFoundException($"Unable to add rental car. AgencyId: {agencyId} does not exists" +
                    $"in a company with Id: {Id}");

            agency.AddRentalCar(rentalCarId);
            AddDomainEvent(new AgencyRentalCarAddedDomainEvent(agencyId, Id, rentalCarId));
        }

    }
}
