using Market.DomainEntities.Entities;
using Market.DomainEntities.Enums;

namespace Market.Services.DTOs;

public class ProductDTOs
{
    public record ProductAddDto(string DisplayName, decimal Price, PricingType PricingType, string Description,
        ICollection<ProductPicture> Pictures, User Seller);

    public record ProductEditDto(int Id, string DisplayName, decimal Price, PricingType PricingType, string Description);
}