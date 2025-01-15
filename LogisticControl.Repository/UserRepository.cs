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

    public async Task<User?> GetUserAsyncByName(string userName)
    {
        IQueryable<User> query = _context.Users;

        query = query.AsNoTracking().Where(u => u.UserName == userName);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<User>?> GetAllUsers()
    {
        IQueryable<User> query = _context.Users;

        return await query.ToListAsync();
    }
}