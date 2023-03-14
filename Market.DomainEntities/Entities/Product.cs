using Market.Domain.Enums;
using Market.DomainEntities.Entities;

namespace Market.Domain.Entities;

public class Product : BaseEntity
{
    public string DisplayName { get; set; }
    
    public decimal Price { get; set; }
    
    public PricingType PricingType { get; set; }
    
    public Person Seller { get; set; }
}