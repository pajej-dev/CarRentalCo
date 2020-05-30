using CarRentalCo.Common.Application.Contracts;
using System.Collections.Generic;

namespace CarRentalCo.Common.Infrastructure.Types
{
    public interface IFilter<TResult, in TQuery> where TQuery : IQuery
    {
        IEnumerable<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }
}