using Market.DomainEntities.Entities;

namespace Market.DomainServices.Interfaces;

public interface IWeatherForecastService : IService
{
    IEnumerable<WeatherForecast> Get();
}