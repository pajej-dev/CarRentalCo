using System.Threading.Tasks;

namespace CarRentalCo.Users.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User userId);

        Task<User> GetByIdAsync(UserId userId);
    }
}
