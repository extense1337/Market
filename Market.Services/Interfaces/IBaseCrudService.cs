using Market.DomainEntities.Entities;

namespace Market.Services.Interfaces;

public interface IBaseCrudService<T> : IService 
    where T : BaseEntity
{
    IAsyncEnumerable<T> GetAll();

    Task<T> GetById(int id);

    Task<bool> Add(T entity);

    Task<bool> Delete(int id);

    Task<bool> Update(int id);
}