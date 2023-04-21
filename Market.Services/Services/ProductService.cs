using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.Services.Interfaces;

namespace Market.Services.Services;

public class ProductService : BaseCrudService<Product>, IProductService
{
    public ProductService(IGenericRepository<Product> productRepository) 
        : base(productRepository) { }
}