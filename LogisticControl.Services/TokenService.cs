using LogisticControl.Domain.Models;
using LogisticControl.Repository.Interfaces;
using LogisticControl.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogisticControl.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public TokenService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> GenerateToken(User user)
    {
        var userDataBase = await _userRepository.GetUserAsyncByEmail(user.Email);
        if (userDataBase is null || userDataBase.Password != user.Password || !userDataBase.Active) return String.Empty;

        var secretyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? String.Empty));
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var signinCredential = new SigningCredentials(secretyKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[]
            {
                new Claim(type: ClaimTypes.Name, userDataBase.Name),
                new Claim(type: ClaimTypes.Role, userDataBase.Role.ToString())
            },
            expires: DateTime.Now.AddHours(2),
            signingCredentials: signinCredential
            );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }
}