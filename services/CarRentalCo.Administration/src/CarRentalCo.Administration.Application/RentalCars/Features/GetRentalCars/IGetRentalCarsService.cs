using CarRentalCo.Administration.Application.RentalCars.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars
{
    public interface IGetRentalCarsService
    {
        Task<ICollection<RentalCarDto>> GetAsync(Guid[] RentalCarIds);
    }
}
