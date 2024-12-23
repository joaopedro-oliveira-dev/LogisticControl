using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context)
    {
        _context = context;
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
    public async Task<Company> GetCompanyAsyncByAddressId(int addressId, bool includeAddress = false)
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
}