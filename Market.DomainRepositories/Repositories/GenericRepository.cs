﻿using System.Linq.Expressions;
using Market.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Market.DomainRepositories.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private MarketDbContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly ILogger _logger;

    public GenericRepository(MarketDbContext context, ILogger logger)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _logger = logger;
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
}