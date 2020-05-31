using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalCo.Administration.Application.Companies.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get;  set; }
        public Guid OwnerId { get;  set; }
        public IList<AgencyDto> Agencies { get;  set; }
        public string Name { get;  set; }
        public DateTime SetUpDate { get;  set; }
        public CompanyContactDto CompanyContact { get;  set; }

    }

    public class AgencyDto
    {
        public Guid Id { get;  set; }
        public AgencyRoleDto Role { get;  set; }
        public AgencyAdressDto Adress { get;  set; }
        public DateTime RoleAssignDate { get;  set; }
        public DateTime SetUpDate { get;  set; }
        public IList<Guid> RentalCars { get;  set; }

    }

    public class CompanyContactDto
    {
        public string Email { get;  set; }
        public string Phone { get;  set; }

    }

    public enum AgencyRoleDto
    {
        Headquarter = 1,
        Standard = 2,
        Premium = 3
    }

    public class AgencyAdressDto
    {
        public string Street { get;  set; }
        public int Number { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get;  set; }
        public string Country { get;  set; }
    }

}
