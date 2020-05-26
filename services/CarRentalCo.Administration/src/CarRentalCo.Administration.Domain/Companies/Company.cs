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
        public IList<Agency> Agencies => agencies;

        private string name;
        private DateTime setUpDate;
        private CompanyContact companyContact;
        private IList<Agency> agencies;

        private Company()
        {
        }

        private Company(CompanyId id, OwnerId ownerId, string name, DateTime setUpDate, CompanyContact companyContact, IList<Agency> agenciess)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.setUpDate = setUpDate;
            this.agencies = agenciess;
            this.companyContact = companyContact;
            this.agencies = agenciess ?? new List<Agency>();

            AddDomainEvent(new CompanyCreatedDomainEvent(Id, OwnerId));
        }

        public static Company Create(CompanyId id, OwnerId ownerId, string name, DateTime setUpDate, CompanyContact companyContact, IList<Agency> agencies = null)
        {
            if (agencies.Count > 10)
                throw new CreateCompanyRejectedException("Company cannot contains more than 10 Agencies");

            return new Company(id, ownerId, name, setUpDate, companyContact, agencies);
        }

        public void AddCompanyAgency(AgencyId agencyId)
        {
            if (agencies.Count == 10)
                throw new AddCompanyAgencyRejectedException("Company cannot contains more than 10 Agencies");

            AgencyRole role;

            if (agencies.Count == 0)
                role = AgencyRole.Headquarter;
            else
                role = AgencyRole.Standard;

            agencies.Add(Agency.Create(agencyId, role));
            AddDomainEvent(new AgencyAddedDomainEvent(agencyId, Id));
        }

        public void ChangeContact(CompanyContact companyContact)
        {
            this.companyContact = companyContact;
        }

        public void ChangeCompanyHeadquarter(AgencyId newHeadquarterId)
        {
            if (agencies.Count == 0)
                throw new ChangeCompanyHeadquarterRejectedException("Company headquarter cannot be changed. Company does not contain any agency");

            var currentHQ = agencies.First(x => x.Role == AgencyRole.Headquarter);
            currentHQ.ChangeRoleToStandard();

            var newHQ = agencies.FirstOrDefault(x => x.Id == newHeadquarterId);
            if (newHQ == null)
                throw new ChangeCompanyHeadquarterRejectedException($"Company headquarter cannot be changed. " +
                    $"Provided '{nameof(AgencyId)}': {newHeadquarterId} not exists in a company");

            newHQ.ChangeRoleToHeadquarter();
        }

        public void AddAgencyRentalCar(AgencyId agencyId, RentalCarId rentalCarId)
        {
            var agency = agencies.FirstOrDefault(x => x.Id == agencyId);

            if(agency == null)
                throw new AgencyNotFoundException($"Unable to add rental car. AgencyId: {agencyId} does not exists" +
                    $"in a company with Id: {Id}");

            agency.AddRentalCar(rentalCarId);
            AddDomainEvent(new AgencyRentalCarAddedDomainEvent(agencyId, Id, rentalCarId));
        }

    }
}
