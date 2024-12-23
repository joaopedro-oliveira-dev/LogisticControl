using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface ICompanyService
{
    void Add(Company entity);
    Task<Company[]> GetAllCompaniesAsync(bool includeAddresses = false);
    Task<Company> GetCompanyAsyncByAddressId(int addressId, bool includeAddresses = false);
    Task<Company> GetCompanyAsyncById(int companyId, bool includeAddresses = false);
    void Update(Company entity);
    void Delete(Company entity);
    Task<bool> SaveChangesAsync();
}