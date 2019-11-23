using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region IItinerary

    public interface IItinerarySnapshot
    {
        int Id { set; get; }

        IFlightSegmentSnapshot Outbound { get; set; }

        IFlightSegmentSnapshot Return { get; set; }

        decimal Price { get; set; }
    }

    public interface IItineraryActions
    {
    }

    public interface IItinerary : IItineraryActions
    {
        int Id { set; get; }

        IFlightSegment Outbound { get; set; }

        IFlightSegment Return { get; set; }

        decimal Price { get; set; }

        double TotalDurationHours { get; }

        string AirlineName { get; }
    }

    public class ItinerarySnapshot : IItinerarySnapshot
    {
        public int Id { get; set; }

        public IFlightSegmentSnapshot Outbound { get; set; }

        public IFlightSegmentSnapshot Return { get; set; }

        public decimal Price { get; set; }
    }

    internal class ItineraryProxy : ObservableProxy<IItinerary, INode>, IItinerary
    {
        public override IItinerary Proxy => this;

        public ItineraryProxy(IObservableObject<IItinerary, INode> target) : base(target)
        {
        }

        public int Id
        {
            get => Read<int>(nameof(Id));
            set => Write(nameof(Id), value);
        }

        public IFlightSegment Outbound
        {
            get => Read<IFlightSegment>(nameof(Outbound));
            set => Write(nameof(Outbound), value);
        }

        public IFlightSegment Return
        {
            get => Read<IFlightSegment>(nameof(Return));
            set => Write(nameof(Return), value);
        }

        public decimal Price
        {
            get => Read<decimal>(nameof(Price));
            set => Write(nameof(Price), value);
        }

        public double TotalDurationHours => Read<double>(nameof(TotalDurationHours));

        public string AirlineName => Read<string>(nameof(AirlineName));
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<IItinerarySnapshot, IItinerary> ItineraryType = Types.Late("LateItineraryType", () => Types.
            Object<IItinerarySnapshot, IItinerary>("ItineraryType")
            .Proxy(x => new ItineraryProxy(x))
            .Snapshot(() => new ItinerarySnapshot())
            .Mutable(o => o.Id, Types.Int)
            .Mutable(o => o.Outbound, FlightSegmentType)
            .Mutable(o => o.Return, FlightSegmentType)
            .Mutable(o => o.Price, Types.Decimal)
            .View(o => o.TotalDurationHours, Types.Double, (o) => o.Outbound.DurationHours + o.Return.DurationHours)
            .View(o => o.AirlineName, Types.String, (o) => (o.Outbound.Airline == o.Return.Airline) ? o.Outbound.Airline : "Multiple airlines"));

         public readonly static IType<IItinerarySnapshot[], IObservableList<INode, IItinerary>> ItineraryListType = Types.Late("LateItineraryListType", () => Types.Optional(Types.List(ItineraryType), Array.Empty<IItinerarySnapshot>()));
    }
}
