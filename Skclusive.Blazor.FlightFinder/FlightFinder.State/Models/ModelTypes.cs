using System;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    public class DateTimeOptions : ICustomTypeOptions<string, DateTime>
    {
        public string Name => "DateTime";

        public DateTime FromSnapshot(string snapshot)
        {
            return DateTime.Parse(snapshot);
        }

        public bool IsTargetType(object value)
        {
            return value is DateTime;
        }

        public string ToSnapshot(DateTime value)
        {
            return value.ToLongTimeString();
        }

        public string Validate(string snapshot)
        {
            if (!DateTime.TryParse(snapshot, out var _))
            {
                return $"{snapshot} is not DateTime value";
            }

            return string.Empty;
        }
    }

    public static class ModelTypes
    {
        public readonly static IType<string, DateTime> DateTimeType = Types.Custom(new DateTimeOptions());

        public readonly static IObjectType<IAirportSnapshot, IAirport> AirportType = Types.
                Object<IAirportSnapshot, IAirport>("Airport")
                .Proxy(x => new AirportProxy(x))
                .Snapshot(() => new AirportSnapshot())
                .Mutable(o => o.Code, Types.String)
                .Mutable(o => o.DisplayName, Types.String);

        public readonly static IType<TicketClass, TicketClass> TicketClassType = Types.Enumeration("TicketClass", TicketClass.Economy, TicketClass.PremiumEconomy, TicketClass.Business, TicketClass.First);

        public readonly static IObjectType<IFlightSegmentSnapshot, IFlightSegment> FlightSegmentType = Types.
                Object<IFlightSegmentSnapshot, IFlightSegment>("FlightSegment")
                .Proxy(x => new FlightSegmentProxy(x))
                .Snapshot(() => new FlightSegmentSnapshot())
                .Mutable(o => o.Airline, Types.String)
                .Mutable(o => o.FromAirportCode, Types.String)
                .Mutable(o => o.ToAirportCode, Types.String)
                .Mutable(o => o.DepartureTime, DateTimeType)
                .Mutable(o => o.ArrivalTime, DateTimeType)
                .Mutable(o => o.DurationHours, Types.Double)
                .Mutable(o => o.TicketClass, TicketClassType);

        public readonly static IObjectType<ISearchCriteriaSnapshot, ISearchCriteria> SearchCriteriaType = Types.
               Object<ISearchCriteriaSnapshot, ISearchCriteria>("SearchCriteria")
               .Proxy(x => new SearchCriteriaProxy(x))
               .Snapshot(() => new SearchCriteriaSnapshot())
               .Mutable(o => o.FromAirport, Types.String)
               .Mutable(o => o.ToAirport, Types.String)
               .Mutable(o => o.OutboundDate, DateTimeType)
               .Mutable(o => o.ReturnDate, DateTimeType)
               .Mutable(o => o.TicketClass, TicketClassType);

        public readonly static IObjectType<IItinerarySnapshot, IItinerary> ItineraryType = Types.
                Object<IItinerarySnapshot, IItinerary>("Itinerary")
                .Proxy(x => new ItineraryProxy(x))
                .Snapshot(() => new ItinerarySnapshot())
                .Mutable(o => o.Outbound, FlightSegmentType)
                .Mutable(o => o.Return, FlightSegmentType)
                .Mutable(o => o.Price, Types.Decimal)
                .View(o => o.TotalDurationHours, Types.Double, (o) => o.Outbound.DurationHours + o.Return.DurationHours)
                .View(o => o.AirlineName, Types.String, (o) => (o.Outbound.Airline == o.Return.Airline) ? o.Outbound.Airline : "Multiple airlines");

        public readonly static IType<IItinerarySnapshot[], IObservableList<INode, IItinerary>> ItineraryListType = Types.Optional(Types.List(ItineraryType), Array.Empty<IItinerarySnapshot>());

        public readonly static IType<IAirportSnapshot[], IObservableList<INode, IAirport>> AirportListType = Types.Optional(Types.List(AirportType), Array.Empty<IAirportSnapshot>());

        public readonly static IObjectType<IAppStateSnapshot, IAppState> AppStateType = Types.
                Object<IAppStateSnapshot, IAppState>("AppState")
                .Proxy(x => new AppStateProxy(x))
                .Snapshot(() => new AppStateSnapshot())
                .Mutable(o => o.SearchInProgress, Types.Boolean)
                .Mutable(o => o.Airports, AirportListType)
                .Mutable(o => o.SearchResults, ItineraryListType)
                .Mutable(o => o.Shortlist, ItineraryListType);
    }
}
