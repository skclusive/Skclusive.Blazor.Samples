using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using Skclusive.Blazor.FlightFinder.Models;
using Skclusive.Blazor.FlightFinder.Service;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.State
{
    public static class FlightFinderExtension
    {
        public static void TryAddFlightFinderStateServices(this IServiceCollection services)
        {
            services.TryAddSingletonEnumerable<JsonConverter, JsonTypeConverter<IAirportSnapshot, AirportSnapshot>>();

            services.TryAddSingletonEnumerable<JsonConverter, JsonTypeConverter<ISearchCriteriaSnapshot, SearchCriteriaSnapshot>>();

            services.TryAddSingletonEnumerable<JsonConverter, JsonTypeConverter<IFlightSegmentSnapshot, FlightSegmentSnapshot>>();

            services.TryAddSingletonEnumerable<JsonConverter, JsonTypeConverter<IItinerarySnapshot, ItinerarySnapshot>>();

            services.TryAddSingletonEnumerable<JsonConverter, JsonTypeConverter<IAppStateSnapshot, AppStateSnapshot>>();

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
