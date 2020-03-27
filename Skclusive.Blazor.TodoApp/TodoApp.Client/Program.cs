using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DevTools;
using Skclusive.Script.DomHelpers;
using Skclusive.Blazor.TodoApp.Extension;

namespace Skclusive.Blazor.TodoApp
{
    public class Program
    {
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.AddTodoApp();

            builder.Services.TryAddDevToolsServices();

            builder.Services.TryAddDomHelpersServices();

            await builder.Build().RunAsync();
        }
    }
}
