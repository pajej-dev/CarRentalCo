using CarRentalCo.Common.Domain;

namespace CarRentalCo.Users.Domain.Users.Exceptions
{
    public class UserEmailAlreadyExistsException : DomainException
    {
        public override string Code => "user_email_already_exists";
        public UserEmailAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
