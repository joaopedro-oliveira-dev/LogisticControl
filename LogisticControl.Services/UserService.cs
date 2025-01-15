using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;

namespace LogisticControl.Services;

public class UserService : IUserService
{
    private readonly IBaseRepository _baseRepository;
    private readonly IUserRepository _userRepository;

    public UserService(IBaseRepository baseRepository, IUserRepository userRepository)
    {
        _baseRepository = baseRepository;
        _userRepository = userRepository;
    }

    public void Add(User entity)
    {
        try
        {
            entity.Active = true;
            _baseRepository.Add(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<User?> GetUserAsyncByName(string userName)
    {
        try
        {
            return await _userRepository.GetUserAsyncByName(userName);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Update(User entity)
    {
        try
        {
            _baseRepository.Update(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public void Delete(User entity)
    {
        try
        {
            _baseRepository.Delete(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }
    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            return await _baseRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }

    public async Task<List<User>?> GetAllUsers()
    {
        try
        {
            return await _userRepository.GetAllUsers();
        }
        catch (Exception ex)
        {
            throw new Exception($"ERRO: {ex.Message}");
        }
    }

}