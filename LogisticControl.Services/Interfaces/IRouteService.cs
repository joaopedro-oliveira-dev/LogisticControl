using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IRouteService
{
    void Add(Route entity);
    Task<Route[]> GetAllRoutesAsync(bool includeDriver = false, bool includeServices = false);
    Task<Route[]> GetRoutesAsyncByDriverId(int driverId, bool includeDriver = false, bool includeServices = false);
    Task<Route?> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false);
    Task<Route?> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false);
    void Update(Route entity);
    void Delete(Route entity);
    Task<bool> SaveChangesAsync();
}