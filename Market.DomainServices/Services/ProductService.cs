using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainServices.Interfaces;

namespace Market.DomainServices.Services;

public class ProductService : BaseCrudService<Product>, IProductService
{
    public ProductService(IGenericRepository<Product> productRepository) 
        : base(productRepository) { }
}