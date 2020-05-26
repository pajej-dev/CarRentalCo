using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class AgencyRoleChangeRejectedException : DomainException
    {
        public override string Code => "agency_change_role_rejected";
        public AgencyRoleChangeRejectedException(string message)
            : base(message)
        {
        }
    }
}
