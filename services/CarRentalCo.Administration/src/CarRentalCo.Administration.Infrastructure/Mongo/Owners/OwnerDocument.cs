using CarRentalCo.Common.Infrastructure.Types;
using System;

namespace CarRentalCo.Administration.Infrastructure.Mongo.Owners
{
    public class OwnerDocument : IIdentifiable
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
