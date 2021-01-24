using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class CompanyAgencyAmountExceededException : DomainException
    {
        public override string Code => "company_agency_amount_exceeded";

        public CompanyAgencyAmountExceededException(string message) : base(message)
        {
        }
    }
}
