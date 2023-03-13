using Market.DomainEntities.Interfaces;

namespace Market.DomainEntities.Entities;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}