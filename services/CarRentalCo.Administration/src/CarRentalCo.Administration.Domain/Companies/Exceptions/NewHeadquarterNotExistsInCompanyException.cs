using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class NewHeadquarterNotExistsInCompanyException : DomainException
    {
        public override string Code => "new_headquarter_not_exists_in_company";
        public NewHeadquarterNotExistsInCompanyException(string message) : base(message)
        {
        }
    }
}
