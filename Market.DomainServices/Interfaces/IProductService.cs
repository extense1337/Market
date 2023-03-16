using Market.DomainEntities.Entities;

namespace Market.DomainServices.Interfaces;

public interface IProductService : IService
{
    IAsyncEnumerable<Product> GetAll();

    Task<Product> GetById(int id);

    Task<bool> Add(Product product);

    Task<bool> Delete(int id);

    Task<bool> Update(int id);
}