using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainServices.Interfaces;

namespace Market.DomainServices.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;

    public ProductService(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }
    
    public IAsyncEnumerable<Product> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Product> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<bool> Add(Product product)
    {
        return await _repository.Add(product);
    }

    public async Task<bool> Delete(int id)
    {
        var product = await _repository.GetById(id);

        return _repository.Delete(product);
    }

    public async Task<bool> Update(int id)
    {
        var product = await _repository.GetById(id);
        
        return _repository.Update(product);
    }
}