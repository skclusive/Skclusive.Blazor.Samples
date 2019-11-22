using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Skclusive.Blazor.FlightFinder.Models;
using Skclusive.Blazor.FlightFinder.Service;

namespace Skclusive.Blazor.FlightFinder.Extension
{
    public static class FlightFinderJsonExtension
    {
        public static void AddFlightFinder(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, AirportSnapshotConverter>();

            services.AddSingleton<JsonConverter, FlightSegmentSnapshotConverter>();

            services.AddSingleton<JsonConverter, ItinerarySnapshotConverter>();

            services.AddSingleton<JsonConverter, AppStateSnapshotConverter>();

            services.AddSingleton((_) => ModelTypes.AppStateType.Create(new AppStateSnapshot
            {
                SearchInProgress = false
            }));

            services.AddSingleton<IAppService, AppService>();
        }
    }
}
