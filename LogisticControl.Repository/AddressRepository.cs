using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AddressRepository(AppDbContext context)
    {
        _context = context;
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
    public async Task<Address?> GetAddressAsyncById(int addressId, bool includeCompany = false)
    {
        IQueryable<Address> query = _context.Addresses;

        if (includeCompany)
        {
            query = query.Include(a => a.Company);
        }

        query = query.AsNoTracking().Where(a => a.Id == addressId);

        return await query.FirstOrDefaultAsync();
    }
}