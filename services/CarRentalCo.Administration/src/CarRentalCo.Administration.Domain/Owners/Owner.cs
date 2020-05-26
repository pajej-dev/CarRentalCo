using CarRentalCo.Administration.Domain.Owners.Events;
using CarRentalCo.Common.Domain;
using CarRentalCo.Common.Other;
using System;

namespace CarRentalCo.Administration.Domain.Owners
{
    public class Owner : AggregateRoot, IEntity<OwnerId>
    {
        public OwnerId Id { get; private set; }

        private string fullName;
        private string email;
        private DateTime DateOfBirth;
        private DateTime CreationDate;
        private DateTime ModificationDate;

        private Owner() { }

        private Owner(Guid id, string fullName, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            this.Id = new OwnerId(id);
            this.fullName = fullName;
            this.email = email;
            this.DateOfBirth = dateOfBirth;
            this.CreationDate = creationDate;

            AddDomainEvent(new OwnerCreatedDomainEvent(Id));
        }

        public static Owner Create(Guid id, string fullName, string email, DateTime dateOfBirth)
        {
            return new Owner(id, fullName, email, dateOfBirth, SystemTime.UtcNow);
        }
    }
}
