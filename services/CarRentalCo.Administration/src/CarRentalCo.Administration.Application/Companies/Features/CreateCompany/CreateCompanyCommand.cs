using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Administration.Application.Companies.Features.CreateCompany
{
    public class CreateCompanyCommand : ICommand
    {
        public CreateCompanyCommand(CompanyId id, OwnerId ownerId, string name, string email, string phone)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public CompanyId Id { get; private set; }
        public OwnerId OwnerId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
