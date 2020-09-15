using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using Skclusive.Blazor.FlightFinder.Models;
using Skclusive.Blazor.FlightFinder.Service;
using Skclusive.Blazor.FlightFinder.Converters;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.State
{
    public static class FlightFinderExtension
    {
        public static void TryAddFlightFinderStateServices(this IServiceCollection services)
        {
            services.TryAddSingleton<JsonConverter, JsonTypeConverter<IAirportSnapshot, AirportSnapshot>>();

            services.TryAddSingleton<JsonConverter, JsonTypeConverter<ISearchCriteriaSnapshot, SearchCriteriaSnapshot>>();

            services.TryAddSingleton<JsonConverter, JsonTypeConverter<IFlightSegmentSnapshot, FlightSegmentSnapshot>>();

            services.TryAddSingleton<JsonConverter, JsonTypeConverter<IItinerarySnapshot, ItinerarySnapshot>>();

            services.TryAddSingleton<JsonConverter, JsonTypeConverter<IAppStateSnapshot, AppStateSnapshot>>();

            services.TryAddScoped((_) => AppStateType.Create(new AppStateSnapshot
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

            services.TryAddScoped<IAppService, AppService>();
        }
    }
}
