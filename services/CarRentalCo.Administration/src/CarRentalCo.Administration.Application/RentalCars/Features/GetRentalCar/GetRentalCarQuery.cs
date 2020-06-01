using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Common.Application.Contracts;
using System;

namespace CarRentalCo.Administration.Application.RentalCars.GetRentalCar
{
    public class GetRentalCarQuery : IQuery<RentalCarDto>
    {
        public Guid RentalCarId { get; set; }
    }
}
