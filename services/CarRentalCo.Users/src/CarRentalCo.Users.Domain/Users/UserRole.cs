using CarRentalCo.Common.Domain;

namespace CarRentalCo.Users.Domain.Users
{
    public class UserRole : ValueObject<UserRole>
    {
        public static UserRole Owner = new UserRole(nameof(Owner));
        public static UserRole Customer = new UserRole(nameof(Customer));

        public string Role{ get; }
        private UserRole()
        {
        }

        private UserRole(string roleName)
        {
            Role = Role;
        }

        protected override bool Equals(ValueObject<UserRole> other)
        {
            var otherRole = other as UserRole;

            if (this.Role != otherRole.Role)
                return false;

            return true;
        }
    }
}