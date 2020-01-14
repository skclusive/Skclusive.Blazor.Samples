using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Blazor.Material.App.View.Data
{
    public class RemoteWeatherForecastService : IWeatherForecastService
    {
        private HttpClient Http { get; }

        public RemoteWeatherForecastService(HttpClient http)
        {
            Http = http;
        }

        public Task<WeatherForecast[]> GetForecastAsync()
        {
            return Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
