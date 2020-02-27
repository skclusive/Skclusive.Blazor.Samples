using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Hosting;
using Skclusive.Material.Layout;
using Skclusive.Blazor.Material.App.View;
using Skclusive.Blazor.Material.App.View.Data;

namespace Skclusive.Blazor.Material.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<AppView>("app");

            builder.Services.AddTransient<IWeatherForecastService, RemoteWeatherForecastService>();

            builder.Services.TryAddLayoutServices(new LayoutConfigBuilder().WithResponsive(true).Build());

            await builder.Build().RunAsync();
        }
    }
}
