namespace Market.Services.Interfaces;

public interface IAuthorizationService
{
    Task<string> AuthorizeAsync(string userName, string password);
}