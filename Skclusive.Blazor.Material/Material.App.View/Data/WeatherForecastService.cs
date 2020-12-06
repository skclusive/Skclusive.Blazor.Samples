using System;
using System.Threading.Tasks;

namespace Skclusive.Material.App.View
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}
