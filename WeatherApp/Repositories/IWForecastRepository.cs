using WeatherApp.Models;

namespace WeatherApp.Repositories
{
    public interface IWForecastRepository
    {
        WeatherResponse GetForecast(string city);
    }
}