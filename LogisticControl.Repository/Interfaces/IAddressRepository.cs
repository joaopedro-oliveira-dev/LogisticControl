using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IAddressRepository
{
    Task<Address[]> GetAllAddressesAsync(bool includeCompany = false);
    Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany = false);
    Task<Address?> GetAddressAsyncById(int addressId, bool includeCompany = false);
}