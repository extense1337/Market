namespace Market.DomainEntities.Entities;

public class Person : BaseEntity
{
    public string UserName { get; set; }
    
    public string FullName { get; set; }
    
    public string Password { get; set; }
    
    public List<Product> SellingProducts { get; set; }
}