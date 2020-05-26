using CarRentalCo.Common.Domain;

namespace CarRentalCo.Administration.Domain.Companies.Exceptions
{
    public class InvalidAgencyAdressParameterException : DomainException
    {
        public override string Code => "invalid_agency_parameter";

        public InvalidAgencyAdressParameterException(string parameter) : base($"Provided Agency parameter: {parameter} is invalid.")
        {
        }
    }
}
