using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface IUserService
{
    void Add(User entity);
    Task<User?> GetUserAsyncByName(string userName);
    void Update(User entity);
    void Delete(User entity);
    Task<bool> SaveChangesAsync();
}