using Market.DomainEntities.Entities;
using Market.DomainEntities.Enums;

namespace Market.Services.DTOs.Product;

public class ProductAddDTO
{
    public string DisplayName { get; set; }

    public decimal Price { get; set; }

    public PricingType PricingType { get; set; }

    public string Description { get; set; }

    public ICollection<ProductPicture> Pictures { get; set; }

    public User Seller { get; set; }
}