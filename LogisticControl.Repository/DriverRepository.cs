using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class DriverRepository : IDriverRepository
{
    private readonly AppDbContext _context;

    public DriverRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Driver[]> GetAllDriversAsync(bool includeRoutes = false)
    {
        IQueryable<Driver> query = _context.Drivers;

        if (includeRoutes)
        {
            query = query.Include(d => d.Routes);
        }

        query = query.AsNoTracking().OrderBy(d => d.Id);

        return await query.ToArrayAsync();
    }
    public async Task<Driver> GetDriverAsyncByRouteId(int routeId, bool includeRoutes = false)
    {
        IQueryable<Driver> query = _context.Drivers;

        if (includeRoutes)
        {
            query = query.Include(d => d.Routes);
        }

        query = query.AsNoTracking().Where(d => d.Routes.Any(a => a.Id == routeId));

        return await query.FirstOrDefaultAsync();
    }
    public async Task<Driver> GetDriverAsyncById(int driverId, bool includeRoutes = false)
    {
        IQueryable<Driver> query = _context.Drivers;

        if (includeRoutes)
        {
            query = query.Include(d => d.Routes);
        }

        query = query.AsNoTracking().Where(d => d.Id == driverId);

        return await query.FirstOrDefaultAsync();
    }
}