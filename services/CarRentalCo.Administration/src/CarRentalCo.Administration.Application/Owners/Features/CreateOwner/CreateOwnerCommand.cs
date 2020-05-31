using CarRentalCo.Administration.Domain.Owners;
using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Administration.Application.Owners.Features.CreateOwner
{
    public class CreateOwnerCommand : ICommand
    {

        public OwnerId Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreationDate { get; private set; }

        public CreateOwnerCommand(OwnerId id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreationDate = creationDate;
        }

    }
}
