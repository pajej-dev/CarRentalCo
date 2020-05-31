using CarRentalCo.Administration.Domain.Companies;
using CarRentalCo.Administration.Domain.Owners;
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
            var ownerExists = await ownerRepository.ExistsAsync(command.OwnerId);
            if (!ownerExists)
            {
                throw new Exception("Cannot create company. OwnerId not exists"); //todo app exception
            }

            var companyContact = CompanyContact.Create(command.Email, command.Phone);
            var company = Company.Create(command.Id, command.OwnerId, command.Name, SystemTime.UtcNow, companyContact);
            await companyRepository.AddAsync(company);
        }
    }
}
