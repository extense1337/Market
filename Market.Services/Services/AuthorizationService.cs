using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.Services.DTOs;
using Market.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Market.Services.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthorizationService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> AuthorizeAsync(UserLoginDto userLoginDto)
    {
        var user = await _userRepository.GetUserAsync(userLoginDto.UserName);

        return user?.Password == userLoginDto.Password
            ? GetJwtAuthToken(user)
            : string.Empty;
    }

    public async Task<bool> RegisterAsync(UserCreateDto userCreateDto)
    {
        var user = userCreateDto.ToUser();

        var result = await _userRepository.CreateUserAsync(user);

        await _userRepository.SaveDbChangesAsync();

        return result;
    }

    private string GetJwtAuthToken(User user)
    {
        var securityKey = _configuration["JwtSecurityKey"] ?? "123456789ABCDEFG";

        var key = Encoding.ASCII.GetBytes(securityKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim("username", user.UserName)
                }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}