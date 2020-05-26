using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class AddCompanyAgencyRejectedException : DomainException
    {
        public override string Code => "add_company_location_rejected";

        public AddCompanyAgencyRejectedException(string message) : base(message)
        {
        }
    }
}
