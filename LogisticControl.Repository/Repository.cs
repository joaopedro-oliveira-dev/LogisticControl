using LogisticControl.Core;
using LogisticControl.Domain;
using Microsoft.EntityFrameworkCore;

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

        query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == addressId);

        return await query.FirstOrDefaultAsync();
    }
}