using CarRentalCo.Orders.Application.Orders.Clients;
using CarRentalCo.Orders.Application.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Clients
{
    public class RentalCarClient : IRentalCarClient
    {
        public RentalCarClient()
        {

        }

        public async Task<RentalCarDto> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(new RentalCarDto { Id = id, PricePerDay = 25, Brand = "Toyota", Model = "Yaris" });
        }

        public async Task<ICollection<RentalCarDto>> GetByIdsAsync(Guid[] ids)
        {
            //todo mocks
            var rentalCars = ids.Select(x => new RentalCarDto { Id = x, PricePerDay = 25, Brand = "Toyota", Model = "Yaris" }).ToList();

            return await Task.FromResult(rentalCars);
        }
    }
}
