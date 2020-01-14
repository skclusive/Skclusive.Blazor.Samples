using System;
using System.Threading.Tasks;

namespace Skclusive.Blazor.Material.App.View.Data
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}
