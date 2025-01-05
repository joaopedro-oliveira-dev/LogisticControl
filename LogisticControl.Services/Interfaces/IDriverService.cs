using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IDriverService
{
    void Add(Driver entity);
    Task<Driver[]> GetAllDriversAsync(bool includeRoutes = false);
    Task<Driver?> GetDriverAsyncByRouteId(int routeId, bool includeRoutes = false);
    Task<Driver?> GetDriverAsyncById(int driverId, bool includeRoutes = false);
    void Update(Driver entity);
    void Delete(Driver entity);
    Task<bool> SaveChangesAsync();
}