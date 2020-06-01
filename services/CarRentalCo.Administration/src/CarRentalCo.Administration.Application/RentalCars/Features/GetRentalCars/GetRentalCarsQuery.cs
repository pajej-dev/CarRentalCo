using CarRentalCo.Administration.Application.RentalCars.Dtos;
using CarRentalCo.Common.Application.Contracts;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Administration.Application.RentalCars.Features.GetRentalCars
{
    public class GetRentalCarsQuery : IQuery<ICollection<RentalCarDto>>
    {
        public Guid[] RentalCarIds { get; set; }
    }
}
