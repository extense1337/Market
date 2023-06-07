using Market.DomainEntities.Enums;

namespace Market.DomainEntities.Entities;

public class Product : BaseEntity
{
    public string DisplayName { get; set; }
    
    public decimal Price { get; set; }
    
    public PricingType PricingType { get; set; }

    public string Description { get; set; }
    
    public virtual User Seller { get; set; }

    public virtual ICollection<ProductPicture> Pictures { get; set; }
}