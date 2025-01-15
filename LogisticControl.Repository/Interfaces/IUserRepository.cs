using LogisticControl.Domain.Models;

namespace LogisticControl.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsyncByName(string userName);

    Task<List<User>?> GetAllUsers();
}