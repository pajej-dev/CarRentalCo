using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.Owners
{
    public interface IOwnerRepository
    {
        Task AddAsync(Owner owner);

        Task<Owner> GetByIdAsync(OwnerId ownerId);
    }
}
