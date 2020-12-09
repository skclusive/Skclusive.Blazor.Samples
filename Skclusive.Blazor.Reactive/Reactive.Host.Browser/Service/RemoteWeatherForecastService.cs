using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Reactive.App.View;

namespace Skclusive.Reactive.Host.Browser
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
            return Http.GetFromJsonAsync<WeatherForecast[]>("./_content/Skclusive.Reactive.App.View/sample-data/weather.json");
        }
    }
}
