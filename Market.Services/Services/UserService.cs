using Market.Database;
using Market.DomainEntities.Entities;
using Market.Services.DTOs;
using Market.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services.Services;

public class UserService : IUserService
{
    private readonly MarketDbContext _dbContext;

    public UserService(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto?> GetUserByUserName(string userName)
    {
        var user = await _dbContext.Users.Where(user => user.UserName == userName).FirstOrDefaultAsync();

        return user is not null
            ? new UserDto(user.UserName, user.FullName, user.Email, user.SellingProducts)
            : null;
    }

    public async Task<bool> CreateUser(UserCreateDto userCreateDto)
    {
        if (_dbContext.Users.Any(userEntry => userEntry.UserName == userCreateDto.UserName))
            return false; // todo: throw - user already exists

        var user = new User
        {
            UserName = userCreateDto.UserName,
            FullName = userCreateDto.FullName,
            Password = userCreateDto.Password,
            Email = userCreateDto.Email
        };

        await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();

        return _dbContext.Users.Any(userEntry => userEntry.UserName == userCreateDto.UserName);
    }

    public async Task<bool> UpdateUser(UserUpdateDto userUpdateDto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userUpdateDto.Id);

        if (user is null) return false;

        user.FullName = userUpdateDto.FullName;
        user.Password = userUpdateDto.Password;

        await _dbContext.SaveChangesAsync();

        return true;
    }
}