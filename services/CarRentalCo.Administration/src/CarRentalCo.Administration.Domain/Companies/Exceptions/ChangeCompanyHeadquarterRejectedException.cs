using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class ChangeCompanyHeadquarterRejectedException : DomainException
    {
        public override string Code => "change_company_headquarter_rejected";

        public ChangeCompanyHeadquarterRejectedException(string message) : base(message)
        {
        }
    }
}
