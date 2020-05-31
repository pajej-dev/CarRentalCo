using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Common.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.Owners.Features.CreateOwner
{
    public class CreateOwnerCommandHandler : ICommandHandler<CreateOwnerCommand>
    {
        private readonly IOwnerRepository ownerRepository;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        public async Task HandleAsync(CreateOwnerCommand command, Guid correlationId = default)
        {
            var owner = Owner.Create(command.Id, command.FullName, command.Email, command.DateOfBirth);
            await ownerRepository.AddAsync(owner);
        }
    }
}
