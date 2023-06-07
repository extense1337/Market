using Market.Database;
using Market.DomainRepositories.Interfaces;

namespace Market.DomainRepositories.Repositories;

public class BaseRepository : IBaseRepository
{
    protected MarketDbContext DbContext { get; }


    protected BaseRepository(MarketDbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <returns>count of modified rows</returns>
    public async Task<int> SaveDbChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
}