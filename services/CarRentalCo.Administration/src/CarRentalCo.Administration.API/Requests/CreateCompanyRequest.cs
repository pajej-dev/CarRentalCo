using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.API.Requests
{
    public class CreateCompanyRequest
    {
        public Guid CompanyId { get;  set; }
        public Guid OwnerId { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }

    }
}
