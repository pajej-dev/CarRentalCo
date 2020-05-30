using CarRentalCo.Common.Infrastructure.Mongo;
using CarRentalCo.Common.Infrastructure.Types;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Orders.Features.GetCustomerOrders;
using CarRentalCo.Orders.Infrastructure.Mappings;
using CarRentalCo.Orders.Infrastructure.Mongo.Orders;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Services
{
    public class GetCustomerOrdersService : IGetCustomerOrdersService
    {
        private readonly IMongoRepository<OrderDocument> mongoRepository;

        public GetCustomerOrdersService(IMongoRepository<OrderDocument> mongoRepository)
        {
            this.mongoRepository = mongoRepository;
        }

        public async Task<PagedResult<OrderDto>> GetAsync(GetCustomerOrdersServiceQuery query)
        {
            var result = await mongoRepository.BrowseAsync(x => x.CustomerId == query.CustomerId.Value, query);
            var res = PagedResult<OrderDto>.From(result, result.Items.Select(x => x.ToDto()));

            return res;
        }
    }
}
