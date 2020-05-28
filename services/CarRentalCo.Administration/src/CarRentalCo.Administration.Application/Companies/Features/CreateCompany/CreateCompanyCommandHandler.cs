using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Administration.Domain.RentalCars;
using CarRentalCo.Common.Application.Contracts;
using CarRentalCo.Common.Application.Handlers;
using CarRentalCo.Common.Other;
using System;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.Companies.Features.CreateCompany
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IOwnerRepository ownerRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IOwnerRepository ownerRepository)
        {
            this.companyRepository = companyRepository;
            this.ownerRepository = ownerRepository;
        }

        public async Task HandleAsync(CreateCompanyCommand command, Guid correlationId = default)
        {
            var owner = ownerRepository.GetByIdAsync(new OwnerId(command.OwnerId));
            if(owner == null)
            {
                throw new Exception("Cannot create company. OwnerId not exists"); //todo app exception
            }

            var companyContact = CompanyContact.Create(command.Email, command.Phone);
            var company = Company.Create(new CompanyId(command.CompanyId), new OwnerId(command.OwnerId), command.Name, SystemTime.UtcNow, companyContact);
            await companyRepository.AddAsync(company);
            //commit
        }
    }

    public class CreateCompanyCommand : ICommand
    {
        public Guid CompanyId { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
