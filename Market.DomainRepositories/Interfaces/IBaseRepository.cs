namespace Market.DomainRepositories.Interfaces;

public interface IBaseRepository
{
    Task<int> SaveDbChangesAsync();
}