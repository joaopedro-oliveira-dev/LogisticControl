using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IDriverRepository
{
    Task<Driver[]> GetAllDriversAsync(bool includeRoutes = false);
    Task<Driver?> GetDriverAsyncByRouteId(int routeId, bool includeRoutes = false);
    Task<Driver?> GetDriverAsyncById(int driverId, bool includeRoutes = false);
}