using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region IItinerary

    public interface IItinerarySnapshot
    {
        IFlightSegmentSnapshot Outbound { get; set; }

        IFlightSegmentSnapshot Return { get; set; }

        decimal Price { get; set; }

        double TotalDurationHours { get; }

        string AirlineName { get; }
    }

    public interface IItineraryActions
    {
    }

    public interface IItinerary : IItineraryActions
    {
        IFlightSegment Outbound { get; set; }

        IFlightSegment Return { get; set; }

        decimal Price { get; set; }

        double TotalDurationHours { get; }

        string AirlineName { get; }
    }

    public class ItinerarySnapshot : IItinerarySnapshot
    {
        public IFlightSegmentSnapshot Outbound { get; set; }

        public IFlightSegmentSnapshot Return { get; set; }

        public decimal Price { get; set; }

        public double TotalDurationHours { get; }

        public string AirlineName { get; }
    }

    internal class ItineraryProxy : ObservableProxy<IItinerary, INode>, IItinerary
    {
        public override IItinerary Proxy => this;

        public ItineraryProxy(IObservableObject<IItinerary, INode> target) : base(target)
        {
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

    public class ItinerarySnapshotConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IItinerarySnapshot));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(ItinerarySnapshot));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(ItinerarySnapshot));
        }
    }

    #endregion
}
