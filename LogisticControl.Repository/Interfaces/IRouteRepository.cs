using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IRouteRepository
{
    Task<Route[]> GetAllRoutesAsync(bool includeDriver = false, bool includeServices = false);
    Task<Route[]> GetRoutesAsyncByDriverId(int driverId, bool includeDriver = false, bool includeServices = false);
    Task<Route> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false);
    Task<Route> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false);
}