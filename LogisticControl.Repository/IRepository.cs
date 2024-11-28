using LogisticControl.Domain.Models;

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

    Task<Address[]> GetAllAddressesAsync(bool includeCompany = false);
    Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany = false);
    Task<Address> GetAddressAsyncById(int addressId, bool includeCompany = false);

    #endregion

    #region COMPANY

    Task<Company[]> GetAllCompaniesAsync(bool includeAddresses = false);
    Task<Company> GetCompanyAsyncByAddressId(int addressId, bool includeAddresses = false);
    Task<Company> GetCompanyAsyncById(int companyId, bool includeAddresses = false);

    #endregion

    #region DRIVER

    Task<Driver[]> GetAllDriversAsync(bool includeRoutes = false);
    Task<Driver> GetDriverAsyncByRouteId(int routeId, bool includeRoutes = false);
    Task<Driver> GetDriverAsyncById(int driverId, bool includeRoutes = false);

    #endregion

    #region ROUTE

    Task<Route[]> GetAllRoutesAsync(bool includeDriver = false, bool includeServices = false);
    Task<Route[]> GetRoutesAsyncByDriverId(int driverId, bool includeDriver = false, bool includeServices = false);
    Task<Route> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false);
    Task<Route> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false);

    #endregion

    #region SERVICE

    Task<Service[]> GetAllServicesAsync(bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByAddressId(int addressId, bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByRouteId(int routeId, bool includeAddress = false, bool includeRoute = false);
    Task<Service> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false);

    #endregion
}