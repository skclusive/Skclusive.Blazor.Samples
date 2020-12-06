using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Mobx.Component;
using Skclusive.Script.DevTools;
using Skclusive.Script.DomHelpers;
using Skclusive.TodoApp.State;
using System.Net.Http;

namespace Skclusive.TodoApp.Client
{
    public class Program
    {
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.TryAddTodoApp();

            var config = new CoreConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .Build();

            builder.Services.TryAddMobxServices(config);

            builder.Services.TryAddDevToolsServices(config);

            builder.Services.TryAddDomHelpersServices(config);

            await builder.Build().RunAsync();
        }
    }
}
