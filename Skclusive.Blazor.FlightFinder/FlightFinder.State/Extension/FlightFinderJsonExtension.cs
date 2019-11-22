using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Skclusive.Blazor.FlightFinder.Models;

namespace Skclusive.Blazor.FlightFinder.Extension
{
    public static class FlightFinderJsonExtension
    {
        public static void AddFlightFinder(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, AirportSnapshotConverter>();

            services.AddSingleton<JsonConverter, FlightSegmentSnapshotConverter>();

            services.AddSingleton<JsonConverter, ItinerarySnapshotConverter>();

            services.AddSingleton<JsonConverter, SearchCriteriaSnapshotConverter>();

            services.AddSingleton<JsonConverter, AppStateSnapshotConverter>();
        }
    }
}
