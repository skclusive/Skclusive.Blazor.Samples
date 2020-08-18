using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.FlightFinder.View;
using Skclusive.Blazor.FlightFinder.Extension;
using Skclusive.Script.DevTools;
using WebWindows.Blazor;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.FlightFinder.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddHttpClient();

            services.AddFlightFinder();

            services.TryAddDevToolsServices(new CoreConfigBuilder().Build());
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
