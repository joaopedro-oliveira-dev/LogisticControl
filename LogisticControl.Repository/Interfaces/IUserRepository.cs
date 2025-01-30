using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IUserRepository
{
    Task<User[]> GetAllUsersAsync();
    Task<User?> GetUserAsyncById(string id);
    Task<User?> GetUserAsyncByEmail(string email);
}