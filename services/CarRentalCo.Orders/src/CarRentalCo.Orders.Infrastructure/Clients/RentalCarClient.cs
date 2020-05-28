using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.CreateOrder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Clients
{
    public class RentalCarClient : IRentalCarClient
    {
        public RentalCarClient()
        {

        }

        public async Task<ICollection<RentalCarDto>> GetByIdsAsync(Guid[] Ids)
        {
            //todo mocks
            var rentalcar = new RentalCarDto { Id = Guid.NewGuid(), PricePerDay = 25, Brand = "Toyota", Model = "Yaris" };
            var rentalcar2 = new RentalCarDto { Id = Guid.NewGuid(), PricePerDay = 35, Brand = "Toyota", Model = "Avensis" };

            return await Task.FromResult(new List<RentalCarDto>() { rentalcar, rentalcar2 });
        }
    }
}
