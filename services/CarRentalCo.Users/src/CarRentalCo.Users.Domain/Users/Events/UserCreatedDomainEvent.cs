using CarRentalCo.Common.Domain;
using System.Collections.Generic;

namespace CarRentalCo.Users.Domain.Users.Events
{
    public class UserCreatedDomainEvent : DomainEvent
    {
        public UserId Id { get; private set; }
        public IList<UserRole> Roles { get; set; }

        public UserCreatedDomainEvent(UserId id, IList<UserRole> roles)
        {
            Id = id;
            Roles = roles;
        }
    }
}
