using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Mobx.Component;
using Skclusive.Blazor.FlightFinder.State;
using Skclusive.Script.DevTools;

namespace Skclusive.Blazor.FlightFinder.View
{
    public static class FlightFinderViewExtension
    {
        public static void TryAddFlightFinderViewServices(this IServiceCollection services, ICoreConfig config)
        {
            services.TryAddMobxServices(config);

            services.TryAddFlightFinderStateServices();

            services.TryAddDevToolsServices(config);
        }
    }
}
