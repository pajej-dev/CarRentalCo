using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class CompanyAgencyNotFoundException : DomainException
    {
        public override string Code => "change_company_headquarter_rejected";

        public CompanyAgencyNotFoundException(string message) : base(message)
        {
        }
    }
}
