using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IServiceService
{
    void Add(Service entity);
    Task<Service[]> GetAllServicesAsync(bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByAddressId(int addressId, bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByRouteId(int routeId, bool includeAddress = false, bool includeRoute = false);
    Task<Service?> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false);
    void Update(Service entity);
    void Delete(Service entity);
    Task<bool> SaveChangesAsync();
}