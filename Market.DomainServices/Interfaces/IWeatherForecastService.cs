using Market.Domain.Entities;

namespace Market.DomainServices.Interfaces;

public interface IWeatherForecastService : IService
{
    IEnumerable<WeatherForecast> Get();
}