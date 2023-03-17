using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainServices.Interfaces;

namespace Market.DomainServices.Services;

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
        return await _repository.Add(entity);
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _repository.GetById(id);

        return _repository.Delete(entity);
    }

    public async Task<bool> Update(int id)
    {
        var entity = await _repository.GetById(id);
        
        return _repository.Update(entity);
    }
}