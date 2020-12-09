using System;
using System.Threading.Tasks;

namespace Skclusive.Reactive.App.View
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync();
    }
}
