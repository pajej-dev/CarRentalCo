using CarRentalCo.Common.Domain;
using System;

namespace CarRentalCo.Users.Domain.Users
{
    public class UserId : TypedIdValueObject
    {
        public UserId(Guid guid) : base(guid)
        {
        }
    }
}
