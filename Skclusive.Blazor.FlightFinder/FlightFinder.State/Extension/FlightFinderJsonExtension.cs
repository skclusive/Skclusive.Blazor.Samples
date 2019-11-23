using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Skclusive.Blazor.FlightFinder.Models;
using Skclusive.Blazor.FlightFinder.Service;

namespace Skclusive.Blazor.FlightFinder.Extension
{
    public static class FlightFinderJsonExtension
    {
        public static void AddFlightFinder(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, AirportSnapshotConverter>();

            services.AddSingleton<JsonConverter, SearchCriteriaSnapshotConverter>();

            services.AddSingleton<JsonConverter, FlightSegmentSnapshotConverter>();

            services.AddSingleton<JsonConverter, ItinerarySnapshotConverter>();

            services.AddSingleton<JsonConverter, AppStateSnapshotConverter>();

            services.AddSingleton((_) => ModelTypes.AppStateType.Create(new AppStateSnapshot
            {
                SearchInProgress = false,

                SortOrder = SortOrder.Price,

                SearchCriteria = new SearchCriteriaSnapshot()
                {
                    FromAirport = "LHR",

                    ToAirport = "SEA",

                    OutboundDate = DateTime.Now.Date,

                    ReturnDate = DateTime.Now.Date.AddDays(7)
                }
            }));

            services.AddSingleton<IAppService, AppService>();
        }
    }
}
