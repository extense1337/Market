using Market.DomainEntities.Entities;
using Market.DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : BaseCrudController<Product>
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
        : base(productService)
    {
        _productService = productService;
    }
}