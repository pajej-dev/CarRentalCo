using CarRentalCo.Common.Infrastructure.Types;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Administration.Infrastructure.Mongo.Companies
{
    public class CompanyDocument : IIdentifiable
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public IList<AgencyDocument> Agencies { get; set; }
        public string Name { get; set; }
        public DateTime SetUpDate { get; set; }
        public CompanyContactDocument CompanyContact { get; set; }

    }

    public class AgencyDocument
    {
        public Guid Id { get; set; }
        public AgencyRoleDocument Role { get; set; }
        public AgencyAdressDocument Adress { get; set; }
        public DateTime RoleAssignDate { get; set; }
        public DateTime SetUpDate { get; set; }
        public IList<Guid> RentalCars { get; set; }

    }

    public class CompanyContactDocument
    {
        public string Email { get; set; }
        public string Phone { get; set; }

    }

    public enum AgencyRoleDocument
    {
        Headquarter = 1,
        Standard = 2,
        Premium = 3
    }

    public class AgencyAdressDocument
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
