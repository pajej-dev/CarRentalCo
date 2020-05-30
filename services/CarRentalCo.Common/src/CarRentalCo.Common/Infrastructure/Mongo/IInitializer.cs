using System.Threading.Tasks;

namespace CarRentalCo.Common.Infrastructure.Mongo
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
