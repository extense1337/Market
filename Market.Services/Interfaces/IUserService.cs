using Market.Services.DTOs;

namespace Market.Services.Interfaces;

public interface IUserService : IService
{
    Task<UserDto?> GetUserByUserName(string userName);
    Task<bool> CreateUser(UserCreateDto userCreateDto);
    Task<bool> UpdateUser(UserUpdateDto userUpdateDto);
}