using LogisticControl.Core;
using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticControl.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User[]> GetAllUsersAsync()
    {
        IQueryable<User> query = _context.Users;

        query.AsNoTracking().OrderBy(u => u.Name);

        return await query.ToArrayAsync();
    }
    public async Task<User?> GetUserAsyncById(string id)
    {
        IQueryable<User> query = _context.Users;

        query = query.AsNoTracking().Where(u => u.Id == id);

        return await query.FirstOrDefaultAsync();
    }
    public async Task<User?> GetUserAsyncByEmail(string email)
    {
        IQueryable<User> query = _context.Users;

        query = query.AsNoTracking().Where(u => u.Email == email);

        return await query.FirstOrDefaultAsync();
    }
}