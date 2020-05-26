using System.Threading.Tasks;

namespace CarRentalCo.Administration.Domain.Companies
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);

        Task<Company> GetByIdAsync(CompanyId companyId);
    }
}
