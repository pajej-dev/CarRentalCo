using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class CreateCompanyRejectedException : DomainException
    {
        public override string Code => "create_company_rejected";
        public CreateCompanyRejectedException(string message) : base(message)
        {
        }
    }
}
