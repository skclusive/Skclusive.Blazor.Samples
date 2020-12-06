using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Messenger.App.View;
using System.Net.Http;

namespace Skclusive.Blazor.Messenger.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // builder.RootComponents.Add<MessengerView>("#app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.TryAddMessengerViewServices
            (
                new MessengerViewConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .Build()
            );

            await builder.Build().RunAsync();
        }
    }
}
