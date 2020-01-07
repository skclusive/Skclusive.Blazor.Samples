using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.FlightFinder.Extension;
using Skclusive.Script.DevTools;
using Skclusive.Blazor.Layout;

namespace Skclusive.Blazor.FlightFinder
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddFlightFinder();

            services.AddDevTools();
		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
