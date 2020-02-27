using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Hosting;
using Skclusive.Blazor.Messenger.App.View;

namespace Skclusive.Blazor.Messenger.Browser.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<MessengerView>("app");

            builder.Services.TryAddMessengerViewServices();

            await builder.Build().RunAsync();
        }
    }
}
