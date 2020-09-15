using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.FlightFinder.View;
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

            services.TryAddFlightFinderViewServices(new CoreConfigBuilder().Build());
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
