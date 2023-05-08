using Market.DomainEntities.Enums;

namespace Market.Services.DTOs.Product;

public class ProductEditDTO
{
    public int Id { get; set; }

    public string DisplayName { get; set; }

    public decimal Price { get; set; }

    public PricingType PricingType { get; set; }

    public string Description { get; set; }
}