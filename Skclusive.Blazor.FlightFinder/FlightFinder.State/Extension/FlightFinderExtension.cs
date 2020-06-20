using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Skclusive.Blazor.FlightFinder.Models;
using Skclusive.Blazor.FlightFinder.Service;
using Skclusive.Blazor.FlightFinder.Converters;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.Extension
{
    public static class FlightFinderExtension
    {
        public static void AddFlightFinder(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, JsonTypeConverter<IAirportSnapshot, AirportSnapshot>>();

            services.AddSingleton<JsonConverter, JsonTypeConverter<ISearchCriteriaSnapshot, SearchCriteriaSnapshot>>();

            services.AddSingleton<JsonConverter, JsonTypeConverter<IFlightSegmentSnapshot, FlightSegmentSnapshot>>();

            services.AddSingleton<JsonConverter, JsonTypeConverter<IItinerarySnapshot, ItinerarySnapshot>>();

            services.AddSingleton<JsonConverter, JsonTypeConverter<IAppStateSnapshot, AppStateSnapshot>>();

            services.AddScoped((_) => AppStateType.Create(new AppStateSnapshot
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

            services.AddScoped<IAppService, AppService>();
        }
    }
}
