using LogisticControl.Core;
using LogisticControl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace LogisticControl.Repository;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }
    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }
    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }
    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
    public async Task<Address[]> GetAllAddressesAsync(bool includeCompany = false)
    {
        IQueryable<Address> query = _context.Addresses;

        if (includeCompany)
        {
            query = query.Include(a => a.Company);
        }

        query = query.AsNoTracking().OrderBy(a => a.Id);

        return await query.ToArrayAsync();
    }
    public async Task<Address[]> GetAddressesAsyncByCompanyId(int companyId, bool includeCompany = false)
    {
        IQueryable<Address> query = _context.Addresses;

        if (includeCompany)
        {
            query = query.Include(a => a.Company);
        }

        query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.CompanyId == companyId);

        return await query.ToArrayAsync();
    }
    public async Task<Address> GetAddressAsyncById(int addressId, bool includeCompany = false)
    {
        IQueryable<Address> query = _context.Addresses;

        if (includeCompany)
        {
            query = query.Include(a => a.Company);
        }

        query = query.AsNoTracking().Where(a => a.Id == addressId);

        return await query.FirstOrDefaultAsync();
    }
    public async Task<Company[]> GetAllCompaniesAsync(bool includeAddresses = false)
    {
        IQueryable<Company> query = _context.Companies;

        if (includeAddresses)
        {
            query = query.Include(c => c.Addresses);
        }

        query = query.AsNoTracking().OrderBy(c => c.Id);

        return await query.ToArrayAsync();
    }
    public async Task<Company> GetCompanyAsyncByAddressId (int addressId, bool includeAddress = false)
    {
        IQueryable<Company> query = _context.Companies;

        if (includeAddress)
        {
            query = query.Include(c => c.Addresses);
        }

        query = query.AsNoTracking().Where(c => c.Addresses.Any(a => a.Id == addressId));

        return await query.FirstOrDefaultAsync();
    }
    public async Task<Company> GetCompanyAsyncById(int companyId, bool includeAddresses = false)
    {
        IQueryable<Company> query = _context.Companies;

        if (includeAddresses)
        {
            query = query.Include(c => c.Addresses);
        }

        query = query.AsNoTracking().Where(c => c.Id == companyId);

        return await query.FirstOrDefaultAsync();
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
    public async Task<Route> GetRouteAsyncByServiceId(int serviceId, bool includeDriver = false, bool includeServices = false)
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
    public async Task<Route> GetRouteAsyncById(int routeId, bool includeDriver = false, bool includeServices = false)
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
    public async Task<Service> GetServiceAsyncById(int serviceId, bool includeAddress = false, bool includeRoute = false)
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