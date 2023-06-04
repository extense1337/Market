using System.Linq.Expressions;
using Market.Database;
using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.DomainRepositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MarketDbContext _dbContext;

    /// <summary>
    /// DbSet of User type
    /// </summary>
    private DbSet<User> UserSet => _dbContext.Users;

    public UserRepository(MarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get user by username
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<User?> GetUserAsync(string userName)
    {
        return await UserSet.Where(user => user.UserName == userName).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> CreateUserAsync(User user)
    {
        await UserSet.AddAsync(user);
        return true;
    }

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool UpdateUserAsync(User user)
    {
        UserSet.Update(user);
        return true;
    }

    /// <summary>
    /// Delete user by username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<bool> DeleteUserAsync(string username)
    {
        var user = await GetUserAsync(username);

        if (user is null)
            return false;

        UserSet.Remove(user);

        return true;
    }

    /// <summary>
    /// Get IQuerable Users by expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IQueryable<User> GetUsers(Expression<Func<User,int,bool>> expression)
    {
        return UserSet.Where(expression);
    }

    /// <summary>
    /// Check is user already exists in database by username
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<bool> IsUserExistAsync(string userName)
    {
        return await UserSet.AnyAsync(user => user.UserName == userName);
    }

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <returns>count of modified rows</returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}