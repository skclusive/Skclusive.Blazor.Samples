using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Messenger.App.View;

namespace Skclusive.Blazor.Messenger.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<MessengerView>("app");

            builder.Services.AddBaseAddressHttpClient();

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
