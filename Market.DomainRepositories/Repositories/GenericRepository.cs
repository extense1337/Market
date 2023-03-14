﻿using System.Linq.Expressions;
using Market.Database;
using Market.DomainRepositories.Interfaces;
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

    public virtual async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual bool Delete(T entity)
    {
        return _dbSet.Remove(entity) is { } entityEntry;
    }

    public virtual IAsyncEnumerable<T> GetAll()
    {
        return _dbSet.AsAsyncEnumerable();
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual bool Update(T entity)
    {
        return _dbSet.Update(entity) is { } entityEntry;
    }
}