using CarRentalCo.Administration.Domain.Owners.Events;
using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Other;
using System;

namespace CarRentalCo.Administration.Domain.Owners
{
    public class Owner : AggregateRoot, IEntity<OwnerId>
    {
        public OwnerId Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }

        public Owner(OwnerId id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreationDate = creationDate;
        }

        public static Owner Create(OwnerId id, string fullName, string email, DateTime dateOfBirth)
        {
            var owner = new Owner(id, fullName, email, dateOfBirth, SystemTime.UtcNow);
            owner.AddDomainEvent(new OwnerCreatedDomainEvent(id));

            return owner;
        }
    }
}
