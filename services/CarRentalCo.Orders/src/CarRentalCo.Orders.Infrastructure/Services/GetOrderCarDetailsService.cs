using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.GetOrderDetails;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Services
{
    public class GetOrderCarDetailsService : IGetOrderCarDetailsService
    {
        private readonly IMongoRepository<OrderDocument> mongoRepository;

        public GetOrderCarDetailsService(IMongoRepository<OrderDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task<OrderCarDetailsDto> GetAsync(Guid orderCarId)
        {
            //todo refactor to get orderCar directly
            var order = await mongoRepository.GetAsync(x => x.OrderCars.Any(x => x.Id == orderCarId));
            var result = order.OrderCars.First(x => x.Id == orderCarId);

            return new OrderCarDetailsDto
            {
                Id = result.Id,
                RentalCarId = result.RentalCarId,
                PricePerDay = result.PricePerDay,
                RentalStartDate = result.RentalStartDate,
                RentalEndDate = result.RentalEndDate
            };
        }
    }
}