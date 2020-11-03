using System;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region IFlightSegment

    public interface IFlightSegmentSnapshot
    {
        string Airline { get; set; }

        string FromAirportCode { get; set; }

        string ToAirportCode { get; set; }

        DateTime DepartureTime { get; set; }

        DateTime ArrivalTime { get; set; }

        double DurationHours { get; set; }

        TicketClass TicketClass { get; set; }
    }

    public interface IFlightSegmentActions
    {
    }

    public interface IFlightSegment : IFlightSegmentActions
    {
        string Airline { get; set; }

        string FromAirportCode { get; set; }

        string ToAirportCode { get; set; }

        DateTime DepartureTime { get; set; }

        DateTime ArrivalTime { get; set; }

        double DurationHours { get; set; }

        TicketClass TicketClass { get; set; }
    }

    public class FlightSegmentSnapshot : IFlightSegmentSnapshot
    {
        public string Airline { get; set; }

        public string FromAirportCode { get; set; }

        public string ToAirportCode { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double DurationHours { get; set; }

        public TicketClass TicketClass { get; set; }
    }

    internal class FlightSegmentProxy : ObservableProxy<IFlightSegment, INode>, IFlightSegment
    {
        public override IFlightSegment Proxy => this;

        public FlightSegmentProxy(IObservableObject<IFlightSegment, INode> target) : base(target)
        {
        }

        public string Airline
        {
            get => Read<string>(nameof(Airline));
            set => Write(nameof(Airline), value);
        }

        public string FromAirportCode
        {
            get => Read<string>(nameof(FromAirportCode));
            set => Write(nameof(FromAirportCode), value);
        }

        public string ToAirportCode
        {
            get => Read<string>(nameof(ToAirportCode));
            set => Write(nameof(ToAirportCode), value);
        }

        public DateTime DepartureTime
        {
            get => Read<DateTime>(nameof(DepartureTime));
            set => Write(nameof(DepartureTime), value);
        }

        public DateTime ArrivalTime
        {
            get => Read<DateTime>(nameof(ArrivalTime));
            set => Write(nameof(ArrivalTime), value);
        }

        public double DurationHours
        {
            get => Read<double>(nameof(DurationHours));
            set => Write(nameof(DurationHours), value);
        }

        public TicketClass TicketClass
        {
            get => Read<TicketClass>(nameof(TicketClass));
            set => Write(nameof(TicketClass), value);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<IFlightSegmentSnapshot, IFlightSegment> FlightSegmentType = Types.Late("LateFlightSegmentType", () => Types.
            Object<IFlightSegmentSnapshot, IFlightSegment>("FlightSegmentType")
            .Proxy(x => new FlightSegmentProxy(x))
            .Snapshot(() => new FlightSegmentSnapshot())
            .Mutable(o => o.Airline, Types.String)
            .Mutable(o => o.FromAirportCode, Types.String)
            .Mutable(o => o.ToAirportCode, Types.String)
            .Mutable(o => o.DepartureTime, DateTimeType)
            .Mutable(o => o.ArrivalTime, DateTimeType)
            .Mutable(o => o.DurationHours, Types.Double)
            .Mutable(o => o.TicketClass, TicketClassType));
    }
}
