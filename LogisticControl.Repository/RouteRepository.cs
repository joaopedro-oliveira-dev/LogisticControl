using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class RouteRepository : IRouteRepository
{
    private readonly AppDbContext _context;

    public RouteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Route[]> GetAllRoutesAsync(bool includeDriver = false, bool includeServices = false)
    {
        IQueryable<Route> query = _context.Routes;

        if (includeDriver)
        {
            query = query.Include(r => r.Driver);
        }

        if (includeServices)
        {
            query = query.Include(r => r.Services);
        }

        query = query.AsNoTracking().OrderBy(r => r.Id);

        return await query.ToArrayAsync();
    }
    public async Task<Route[]> GetRoutesAsyncByDriverId(int driverId, bool includeDriver = false, bool includeServices = false)
    {
        IQueryable<Route> query = _context.Routes;

        if (includeDriver)
        {
            query = query.Include(r => r.Driver);
        }

        if (includeServices)
        {
            query = query.Include(r => r.Services);
        }

        query = query.AsNoTracking().Where(r => r.DriverId == driverId);

        return await query.ToArrayAsync();
    }
    public async Task<Route?> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false)
    {
        IQueryable<Route> query = _context.Routes;

        if (includeDriver)
        {
            query = query.Include(r => r.Driver);
        }

        if (includeServices)
        {
            query = query.Include(r => r.Services);
        }

        query = query.AsNoTracking().Where(r => r.Services.Any(s => s.Id == serviceId));

        return await query.FirstOrDefaultAsync();
    }
    public async Task<Route?> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false)
    {
        IQueryable<Route> query = _context.Routes;

        if (includeDriver)
        {
            query = query.Include(r => r.Driver);
        }

        if (includeServices)
        {
            query = query.Include(r => r.Services);
        }

        query = query.AsNoTracking().Where(r => r.Id == routeId);

        return await query.FirstOrDefaultAsync();
    }
}