using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Service[]> GetAllServicesAsync(bool includeAddress = false, bool includeRoute = false)
    {
        IQueryable<Service> query = _context.Services;

        if (includeAddress)
        {
            query = query.Include(s => s.Address);
        }

        if (includeRoute)
        {
            query = query.Include(s => s.Route);
        }

        query = query.AsNoTracking().OrderBy(s => s.Id);

        return await query.ToArrayAsync();
    }
    public async Task<Service[]> GetServicesAsyncByAddressId(int addressId, bool includeAddress = false, bool includeRoute = false)
    {
        IQueryable<Service> query = _context.Services;

        if (includeAddress)
        {
            query = query.Include(s => s.Address);
        }

        if (includeRoute)
        {
            query = query.Include(s => s.Route);
        }

        query = query.AsNoTracking().Where(s => s.AddressId == addressId);

        return await query.ToArrayAsync();
    }
    public async Task<Service[]> GetServicesAsyncByRouteId(int routeId, bool includeAddress = false, bool includeRoute = false)
    {
        IQueryable<Service> query = _context.Services;

        if (includeAddress)
        {
            query = query.Include(s => s.Address);
        }

        if (includeRoute)
        {
            query = query.Include(s => s.Route);
        }

        query = query.AsNoTracking().Where(s => s.RouteId == routeId);

        return await query.ToArrayAsync();
    }
    public async Task<Service?> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false)
    {
        IQueryable<Service> query = _context.Services;

        if (includeAddress)
        {
            query = query.Include(s => s.Address);
        }

        if (includeRoute)
        {
            query = query.Include(s => s.Route);
        }

        query = query.AsNoTracking().Where(s => s.Id == serviceId);

        return await query.FirstOrDefaultAsync();
    }
}