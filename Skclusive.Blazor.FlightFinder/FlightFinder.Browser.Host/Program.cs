using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.FlightFinder.View;
using Skclusive.Blazor.FlightFinder.Extension;
using Skclusive.Script.DevTools;
using System.Net.Http;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.FlightFinder.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<AppView>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddFlightFinder();

            builder.Services.TryAddDevToolsServices(new CoreConfigBuilder().Build());

            await builder.Build().RunAsync();
        }
    }
}
