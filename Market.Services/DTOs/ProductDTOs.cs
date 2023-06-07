using Market.DomainEntities.Entities;
using Market.DomainEntities.Enums;

namespace Market.Services.DTOs;

public class ProductDTOs
{
    public record ProductAddDto(string DisplayName, decimal Price, PricingType PricingType, string Description,
        ICollection<ProductPicture> Pictures, User Seller)
    {
        public Product ToProduct()
        {
            return new Product
            {
                DisplayName = DisplayName,
                Price = Price,
                PricingType = PricingType,
                Description = Description,
                Pictures = Pictures,
                Seller = Seller
            };
        }
    }

    public record ProductEditDto(int Id, string DisplayName, decimal Price, PricingType PricingType, string Description)
    {
        public Product ToProduct()
        {
            return new Product
            {
                Id = Id,
                DisplayName = DisplayName,
                Price = Price,
                PricingType = PricingType,
                Description = Description
            };
        }
    }

    public record ProductDeleteDto(int Id)
    {
        public Product ToProduct() { return new Product { Id = Id }; }
    };
}