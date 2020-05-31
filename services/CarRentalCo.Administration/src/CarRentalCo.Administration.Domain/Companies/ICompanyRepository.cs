using CarRentalCo.Common.Domain;
using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.Companies
{
    public interface ICompanyRepository: IDomainRepository
    {
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task<bool> ExistsAsync(CompanyId id);
        Task<Company> GetByIdAsync(CompanyId companyId);
    }
}
