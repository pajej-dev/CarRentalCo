using CarRentalCo.Common.Domain;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.Owners
{
    public interface IOwnerRepository : IDomainRepository
    {
        Task AddAsync(Owner owner);
        Task<bool> ExistsAsync(OwnerId id);

        Task<Owner> GetByIdAsync(OwnerId ownerId);

    }
}
