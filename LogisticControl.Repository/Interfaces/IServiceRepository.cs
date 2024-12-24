using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IServiceRepository
{
    Task<Service[]> GetAllServicesAsync(bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByAddressId(int addressId, bool includeAddress = false, bool includeRoute = false);
    Task<Service[]> GetServicesAsyncByRouteId(int routeId, bool includeAddress = false, bool includeRoute = false);
    Task<Service?> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false);
}