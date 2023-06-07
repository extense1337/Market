using Market.Services.DTOs;

namespace Market.Services.Interfaces;

public interface IAuthorizationService
{
    Task<string> AuthorizeAsync(UserLoginDto userLoginDto);

    Task<bool> RegisterAsync(UserCreateDto userCreateDto);
}