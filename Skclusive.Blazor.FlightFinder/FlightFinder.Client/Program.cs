using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
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

            builder.Services.AddFlightFinder();

            builder.Services.AddDevTools();

            await builder.Build().RunAsync();
        }
	}
}
