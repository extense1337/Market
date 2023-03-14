using System.Linq.Expressions;

namespace Market.DomainRepositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IAsyncEnumerable<T> GetAll();
    Task<T> GetById(int id);
    Task<bool> Add(T entity);
    bool Delete(T entity);
    bool Update(T entity);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
}