using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainRepositories.Repositories;
using Market.Services.Interfaces;
using Market.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Services;

/// <summary>
/// Main dependency container
/// </summary>
public static class DependencyContainer
{
    /// <summary>
    /// Initialize dependencies
    /// </summary>
    /// <param name="services"></param>
    public static void Initialize(IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);
    }

    /// <summary>
    /// Register repositories
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
    
    /// <summary>
    /// Register services
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
    }
}