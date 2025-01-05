using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IAddressService
{
    void Add(Address entity);
    Task<Address[]> GetAllAddressesAsync(bool includeCompany = false);
    Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany = false);
    Task<Address?> GetAddressAsyncById(int addressId, bool includeCompany = false);
    void Update(Address entity);
    void Delete(Address entity);
    Task<bool> SaveChangesAsync();
}