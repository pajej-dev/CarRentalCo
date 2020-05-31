using System;

namespace CarRentalCo.Administration.API.Requests
{
    public class AddCompanyAgencyRequest
    {
        public Guid CompanyId { get; set; }
        public Guid AgencyId { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
