using CarRentalCo.Common.Application.Contracts;

namespace CarRentalCo.Common.Infrastructure.Types
{
    public interface IPagedQuery : IQuery
    {
        int Page { get; }
        int Results { get; }
        string OrderBy { get; }
        string SortOrder { get; }
    }
}