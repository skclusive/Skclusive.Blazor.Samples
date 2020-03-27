using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.FlightFinder.Extension;
using Skclusive.Script.DevTools;

namespace Skclusive.Blazor.FlightFinder
{
	public class Program
	{
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.AddFlightFinder();

            builder.Services.TryAddDevToolsServices();

            await builder.Build().RunAsync();
        }
	}
}
