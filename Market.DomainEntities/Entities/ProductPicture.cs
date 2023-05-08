namespace Market.DomainEntities.Entities;

public class ProductPicture : BaseEntity
{
    public Product Product { get; set; }

    public byte[] Content { get; set; }

    public DateTime UploadDate { get; set; }
}