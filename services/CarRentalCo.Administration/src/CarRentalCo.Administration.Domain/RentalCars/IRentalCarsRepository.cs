using CarRentalCo.Common.Domain;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public interface IRentalCarsRepository// : IDomainRepository
    {
        Task AddAsync(RentalCar company);
        Task UpdateAsync(RentalCar company);
        Task<bool> ExistsAsync(RentalCarId id);
        Task<RentalCar> GetByIdAsync(RentalCarId id);
    }
}
