﻿using Market.DomainEntities.Entities;
using Market.DomainRepositories.Interfaces;
using Market.DomainRepositories.Repositories;
using Market.DomainServices.Interfaces;
using Market.DomainServices.Services;

namespace Market.WebApi;

/// <summary>
/// Основной контейнер зависимостей
/// </summary>
public static class DependencyContainer
{
    /// <summary>
    /// Инициализировать зависимости
    /// </summary>
    /// <param name="services"></param>
    public static void Initialize(IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);
    }

    /// <summary>
    /// Регистрация репозиториев
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
    }
    
    /// <summary>
    /// Регистрация сервисов
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        services.AddScoped<IProductService, ProductService>();
    }
}