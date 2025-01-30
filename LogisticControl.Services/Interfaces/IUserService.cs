using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IUserService
{
    void Add(User entity);
    Task<User?> GetUserAsyncById(string id);
    Task<User?> GetUserAsyncByEmail(string email);
    Task<User[]> GetAllUsersAsync();
    void Update(User entity);
    void Delete(User entity);
    Task<bool> SaveChangesAsync();
}