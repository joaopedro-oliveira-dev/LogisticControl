using LogisticControl.Domain;

namespace LogisticControl.Repository;

public interface IRepository
{
    #region GERAL

    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    #endregion

    #region ADDRESS

    Task<Address[]> GetAllAddressesAsync(bool includeCompany);
    Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany);
    Task<Address> GetAddressAsyncById(int addressId, bool includeCompany);

    #endregion
}