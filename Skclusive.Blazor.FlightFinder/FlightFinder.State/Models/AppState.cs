using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using System.Collections.Generic;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region IAppState

    public interface IAppStateSnapshot
    {
        bool SearchInProgress { get; set; }

		IItinerary[] SearchResults { get; set; }

		IItinerary[] Shortlist { get; set; }

		IAirport[] Airports { get; set; }
    }

    public interface IAppStateActions
    {
    }

    public interface IAppState : IAppStateActions
    {
        bool SearchInProgress { get; set; }

		IList<IItinerary> SearchResults { get; set; }

		IList<IItinerary> Shortlist { get; set; }

		IList<IAirport> Airports { get; set; }
    }

    public class AppStateSnapshot : IAppStateSnapshot
    {
        public bool SearchInProgress { get; set; }

		public IItinerary[] SearchResults { get; set; }

		public IItinerary[] Shortlist { get; set; }

		public IAirport[] Airports { get; set; }
    }

    internal class AppStateProxy : ObservableProxy<IAppState, INode>, IAppState
    {
        public override IAppState Proxy => this;

        public AppStateProxy(IObservableObject<IAppState, INode> target) : base(target)
        {
        }

        public bool SearchInProgress
        {
            get => Read<bool>(nameof(SearchInProgress));
            set => Write(nameof(SearchInProgress), value);
        }

        public IList<IItinerary> SearchResults
        {
            get => Read<IList<IItinerary>>(nameof(SearchResults));
            set => Write(nameof(SearchResults), value);
        }

        public IList<IItinerary> Shortlist
        {
            get => Read<IList<IItinerary>>(nameof(Shortlist));
            set => Write(nameof(Shortlist), value);
        }

        public IList<IAirport> Airports
        {
            get => Read<IList<IAirport>>(nameof(Airports));
            set => Write(nameof(Airports), value);
        }
    }

    public class AppStateSnapshotConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IAppStateSnapshot));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(AppStateSnapshot));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(AppStateSnapshot));
        }
    }

    #endregion
}
