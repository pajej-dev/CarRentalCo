using System;

namespace CarRentalCo.Administration.API.Requests
{
    public class AddAgencyRentalCarRequest
    {
        public Guid CompanyId { get; set; }
        public Guid AgencyId { get; set; }
        public Guid RentalCarId { get; set; }

    }
}
