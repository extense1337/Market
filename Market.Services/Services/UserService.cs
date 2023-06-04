using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.Services.DTOs;
using Market.Services.Interfaces;

namespace Market.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Get user by username
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<UserDto?> GetUserByUserName(string userName)
    {
        var user = await _userRepository.GetUserAsync(userName);

        return user is not null
            ? new UserDto(user.UserName, user.FullName, user.Email, user.SellingProducts)
            : null;
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="userCreateDto"></param>
    /// <returns></returns>
    public async Task<bool> CreateUser(UserCreateDto userCreateDto)
    {
        var isUserExist = await _userRepository.IsUserExistAsync(userCreateDto.UserName);

        if (isUserExist)
            return false;

        var user = new User
        {
            UserName = userCreateDto.UserName,
            FullName = userCreateDto.FullName,
            Password = userCreateDto.Password,
            Email = userCreateDto.Email
        };

        await _userRepository.CreateUserAsync(user);

        return await _userRepository.IsUserExistAsync(userCreateDto.UserName);
    }

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="userUpdateDto"></param>
    /// <returns></returns>
    public async Task<bool> UpdateUser(UserUpdateDto userUpdateDto)
    {
        var user = await _userRepository.GetUserAsync(userUpdateDto.UserName);

        if (user is null) return false;

        user.FullName = userUpdateDto.FullName;
        user.Password = userUpdateDto.Password;

        return await _userRepository.SaveChangesAsync() > 0;
    }
}