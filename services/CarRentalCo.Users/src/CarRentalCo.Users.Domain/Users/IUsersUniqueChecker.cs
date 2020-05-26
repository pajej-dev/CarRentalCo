using System.Threading.Tasks;

namespace CarRentalCo.Users.Domain.Users
{
    public interface IUsersUniqueChecker
    {
        bool IsUnique();
    }
}