using AutoFixture;
using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.Companies.Events;
using CarRentalCo.Administration.Domain.Companies.Exceptions;
using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Other;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CarRentalCo.Administration.Tests.Unit.Domain
{
    public class CompanyTests
    {
        private readonly Fixture _fixture;

        public CompanyTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Create_ParametersProvided_CompanyCreatedDomainEventAdded()
        {
            //Given
            var companyId = _fixture.Create<CompanyId>();
            var ownerId = _fixture.Create<OwnerId>();
            var name = _fixture.Create<string>();
            var setupDate = _fixture.Create<DateTime>();

            string email = "someEmail@email.com";
            string phone = _fixture.Create<string>();
            var companyContact = CompanyContact.Create(email, phone);

            //When
            var sut = Company.Create(companyId, ownerId, name, setupDate, companyContact);

            //Then
            sut.Events.Should().HaveCount(1);
            sut.Events.First().Should().BeOfType<CompanyCreatedDomainEvent>();
        }

        [Fact]
        public void AddCompanyAgency_TenAgencyAlreadyExists_ThrowsCompanyAgencyAmountExceededException()
        {
            //Given
            var sut = CreateValidCompany();
            var agencyAdress = _fixture.Create<AgencyAdress>();

            SeedCompanyAgencies(sut, 10);

            //When
            Action action = () => sut.AddCompanyAgency(new AgencyId(Guid.NewGuid()), agencyAdress);

            //Then
            action.Should().ThrowExactly<CompanyAgencyAmountExceededException>();
        }

        [Fact]
        public void AddCompanyAgency_NoAgencyAlreadyExists_AddAgencyAsHeadquarter()
        {
            //Given
            var sut = CreateValidCompany();
            var agencyAdress = _fixture.Create<AgencyAdress>();

            //When
            sut.AddCompanyAgency(new AgencyId(Guid.NewGuid()), agencyAdress);

            //Then
            sut.Agencies.First().Role.Should().Be(AgencyRole.Headquarter);
        }

        [Fact]
        public void AddCompanyAgency_OneUpToNineAgenciesAlreadyExists_AddAgencyAsStandard()
        {
            //Given
            var sut = CreateValidCompany();
            var agencyAdress = _fixture.Create<AgencyAdress>();
            var random = new Random().Next(1, 9);
            SeedCompanyAgencies(sut, random);
            var expectedAgencyId = new AgencyId(Guid.NewGuid());

            //When
            sut.AddCompanyAgency(expectedAgencyId, agencyAdress);

            //Then
            sut.Agencies.Single(x => x.Id.Equals(expectedAgencyId)).Role.Should().Be(AgencyRole.Standard);
        }

        [Fact]
        public void AddCompanyAgency_StateIsValid_AgencyAddedDomainEventCreated()
        {
            //Given
            var sut = CreateValidCompany();
            var agencyAdress = _fixture.Create<AgencyAdress>();
            var random = new Random().Next(1, 9);
            SeedCompanyAgencies(sut, random);

            //When
            sut.AddCompanyAgency(new AgencyId(Guid.NewGuid()), agencyAdress);

            //Then
            sut.Events.Should().Contain(x => x.GetType() == typeof(AgencyAddedDomainEvent));
        }

        [Fact]
        public void ChangeContact_CompanyContactProvided_CompanyHasNewContactAssigned()
        {
            //Given
            var sut = CreateValidCompany();
            var newCompanyContact = _fixture.Create<CompanyContact>();

            //When
            sut.ChangeContact(newCompanyContact);

            //Then
            sut.CompanyContact.Should().Be(newCompanyContact);
        }

        [Fact]
        public void ChangeCompanyHeadquarter_NoAgencyAlreadyExists_ThrowsCompanyAgencyNotFoundException()
        {
            //Given
            var sut = CreateValidCompany();
            var newAgencyId = new AgencyId(Guid.NewGuid());

            //When
            Action action = () => sut.ChangeCompanyHeadquarter(newAgencyId);

            //Then
            action.Should().ThrowExactly<CompanyAgencyNotFoundException>();
        }

        [Fact]
        public void ChangeCompanyHeadquarter_NewHeadquarterNotExists_ThrowsNewHeadquarterNotExistsInCompanyException()
        {
            //Given
            var sut = CreateValidCompany();
            SeedCompanyAgencies(sut, 1);
            var newAgencyId = new AgencyId(Guid.NewGuid());

            //When
            Action action = () => sut.ChangeCompanyHeadquarter(newAgencyId);

            //Then
            action.Should().ThrowExactly<NewHeadquarterNotExistsInCompanyException>();
        }

        [Fact]
        public void ChangeCompanyHeadquarter_NewHeadquarterExistsInCompany_HeadquarterIsChangedAndDomainEventExists()
        {
            //Given
            //turn back time to pass agency date validation
            var currentDate = SystemTime.UtcNow;
            SystemTime.Set(currentDate.Subtract(TimeSpan.FromDays(50)));

            var sut = CreateValidCompany();
            SeedCompanyAgencies(sut, 5);
            var newAgencyHeadquarterId = sut.Agencies.First(agency => agency.Role != AgencyRole.Headquarter).Id;
            var initialAgencyHeadquarterId = sut.Agencies.First(agency => agency.Role == AgencyRole.Headquarter).Id;

            //reset time to continue processing
            SystemTime.Reset();

            //When
            sut.ChangeCompanyHeadquarter(newAgencyHeadquarterId);

            //Then
            sut.Agencies.First(x => x.Role == AgencyRole.Headquarter).Id.Should().Be(newAgencyHeadquarterId);
            sut.Agencies.First(x => x.Id.Equals(initialAgencyHeadquarterId)).Role.Should().Be(AgencyRole.Standard);
            sut.Events.Should().Contain(ev => ev.GetType() == typeof(CompanyHeadquarterChangedEvent));
        }

        [Fact]
        public void AddAgencyRentalCar_CompanyAgencyNotExists_ThrowCompanyAgencyNotFoundException()
        {
            //Given
            var sut = CreateValidCompany();

            //When
            Action action = () => sut.AddAgencyRentalCar(new AgencyId(Guid.NewGuid()), new RentalCarId(Guid.NewGuid()));

            //Then
            action.Should().ThrowExactly<CompanyAgencyNotFoundException>();
        }

        [Fact]
        public void AddAgencyRentalCar_CompanyAgencyExistsAndRentalCarIsNew_RentalCarAddedToCompanyAgency()
        {
            //Given
            var sut = CreateValidCompany();
            SeedCompanyAgencies(sut, 1);
            var existingAgencyId = sut.Agencies.First().Id;
            var newRentalCarId = new RentalCarId(Guid.NewGuid());

            //When
            sut.AddAgencyRentalCar(existingAgencyId, newRentalCarId);

            //Then
            sut.Agencies.First().RentalCars.First().Should().Be(newRentalCarId);
        }

        private Company CreateValidCompany()
        {
            var companyId = _fixture.Create<CompanyId>();
            var ownerId = _fixture.Create<OwnerId>();
            var name = _fixture.Create<string>();
            var setupDate = _fixture.Create<DateTime>();

            string email = "someEmail@email.com";
            string phone = _fixture.Create<string>();
            var companyContact = CompanyContact.Create(email, phone);

            return Company.Create(companyId, ownerId, name, setupDate, companyContact);
        }

        private void SeedCompanyAgencies(Company company, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var agencyAdress = _fixture.Create<AgencyAdress>();
                company.AddCompanyAgency(new AgencyId(Guid.NewGuid()), agencyAdress);
            }
        }
    }
}
