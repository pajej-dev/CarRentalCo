using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.RentalCars
{
    public interface IRentalCarsRepository
    {
        Task AddAsync(RentalCar rentalCar);

        Task<RentalCar> GetByIdAsync(RentalCarId rentalCarId);
    }
}
