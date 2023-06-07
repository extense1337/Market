using System.Linq.Expressions;
using Market.Database;
using Market.DomainRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.DomainRepositories.Repositories;

public sealed class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MarketDbContext dbContext) : base(dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public bool Delete(T entity)
    {
        return _dbSet.Remove(entity) is { } entityEntry;
    }

    public IAsyncEnumerable<T> GetAll()
    {
        return _dbSet.AsAsyncEnumerable();
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public bool Update(T entity)
    {
        return _dbSet.Update(entity) is { } entityEntry;
    }
}