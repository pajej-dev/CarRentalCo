using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class AgencyNotFoundException : DomainException
    {
        public override string Code => "agency_not_found_exception";
        public AgencyNotFoundException(string message) : base(message)
        {
        }
    }
}
