using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface ICompanyRepository
{
    Task<Company[]> GetAllCompaniesAsync(bool includeAddresses = false);
    Task<Company> GetCompanyAsyncByAddressId(int addressId, bool includeAddresses = false);
    Task<Company> GetCompanyAsyncById(int companyId, bool includeAddresses = false);
}