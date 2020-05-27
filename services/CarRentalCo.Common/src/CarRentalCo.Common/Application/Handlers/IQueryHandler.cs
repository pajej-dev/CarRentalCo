using CarRentalCo.Common.Application.Contracts;
using System.Threading.Tasks;

namespace CarRentalCo.Common.Application.Handlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
