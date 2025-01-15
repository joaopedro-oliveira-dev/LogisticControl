using LogisticControl.Domain.Models;

namespace LogisticControl.Services.Interfaces;

public interface ITokenService
{
    Task<string> GenerateToken(User user);
}