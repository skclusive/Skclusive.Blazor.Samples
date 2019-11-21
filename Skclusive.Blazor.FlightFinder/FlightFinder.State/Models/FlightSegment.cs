using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region ISearchCriteria

    public interface ISearchCriteriaSnapshot
    {
        string FromAirport { get; set; }

        string ToAirport { get; set; }

        DateTime OutboundDate { get; set; }

        DateTime ReturnDate { get; set; }

        TicketClass TicketClass { get; set; }
    }

    public interface ISearchCriteriaActions
    {
    }

    public interface ISearchCriteria : ISearchCriteriaSnapshot, ISearchCriteriaActions
    {
    }

    public class SearchCriteriaSnapshot : ISearchCriteriaSnapshot
    {
        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime OutboundDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public TicketClass TicketClass { get; set; }
    }

    internal class SearchCriteriaProxy : ObservableProxy<ISearchCriteria, INode>, ISearchCriteria
    {
        public override ISearchCriteria Proxy => this;

        public SearchCriteriaProxy(IObservableObject<ISearchCriteria, INode> target) : base(target)
        {
        }

        public string FromAirport
        {
            get => Read<string>(nameof(FromAirport));
            set => Write(nameof(FromAirport), value);
        }

        public string ToAirport
        {
            get => Read<string>(nameof(ToAirport));
            set => Write(nameof(ToAirport), value);
        }

        public DateTime OutboundDate
        {
            get => Read<DateTime>(nameof(OutboundDate));
            set => Write(nameof(OutboundDate), value);
        }

        public DateTime ReturnDate
        {
            get => Read<DateTime>(nameof(ReturnDate));
            set => Write(nameof(ReturnDate), value);
        }

        public TicketClass TicketClass
        {
            get => Read<TicketClass>(nameof(TicketClass));
            set => Write(nameof(TicketClass), value);
        }
    }

    public class SearchCriteriaSnapshotConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ISearchCriteriaSnapshot));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(SearchCriteriaSnapshot));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(SearchCriteriaSnapshot));
        }
    }

    #endregion
}
