using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.Services.Interfaces;

namespace Market.Services.Services;

public class BaseCrudService<T> : IBaseCrudService<T>
    where T : BaseEntity
{
    private readonly IGenericRepository<T> _repository;
    
    protected BaseCrudService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    
    public IAsyncEnumerable<T> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<T> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<bool> Add(T entity)
    {
        var result = await _repository.Add(entity);

        await _repository.SaveDbChangesAsync();

        return result;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _repository.GetById(id);

        var result = _repository.Delete(entity);

        await _repository.SaveDbChangesAsync();

        return result;
    }

    public async Task<bool> Update(int id)
    {
        var entity = await _repository.GetById(id);
        
        var result = _repository.Update(entity);

        await _repository.SaveDbChangesAsync();

        return result;
    }
}