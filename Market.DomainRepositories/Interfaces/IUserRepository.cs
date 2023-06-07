using System.Linq.Expressions;
using Market.DomainEntities.Entities;

namespace Market.DomainRepositories.Interfaces;

public interface IUserRepository : IBaseRepository
{
    Task<User?> GetUserAsync(string userName);
    Task<bool> CreateUserAsync(User user);
    bool UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(string userName);
    public IQueryable<User> GetUsers(Expression<Func<User, int, bool>> expression);
    Task<bool> IsUserExistAsync(string userName);
}