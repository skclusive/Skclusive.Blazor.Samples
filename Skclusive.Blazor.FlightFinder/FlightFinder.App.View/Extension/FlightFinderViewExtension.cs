using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Mobx.Component;
using Skclusive.FlightFinder.App.State;
using Skclusive.Script.DevTools;

namespace Skclusive.FlightFinder.App.View
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
