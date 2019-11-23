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

        SortOrder SortOrder { get; set; }

        ISearchCriteriaSnapshot SearchCriteria { get; set; }

		IItinerarySnapshot[] SearchResults { get; set; }

		IItinerarySnapshot[] Shortlist { get; set; }

		IAirportSnapshot[] Airports { get; set; }
    }

    public interface IAppStateActions
    {
        void SetSortOrder(SortOrder sortOrder);

        void AddToShortlist(IItinerarySnapshot itinerary);

        void RemoveFromShortlist(IItinerarySnapshot itinerary);

        void BeginAirportFetch();

        void EndAirportFetch(IAirportSnapshot[] airports);

        void BeginItinerarySearch();

        void EndItinerarySearch(IItinerarySnapshot[] itineraries);
    }

    public interface IAppState : IAppStateActions
    {
        bool SearchInProgress { get; set; }

        SortOrder SortOrder { get; set; }

        ISearchCriteria SearchCriteria { get; set; }

		IList<IItinerary> SearchResults { get; set; }

		IList<IItinerary> Shortlist { get; set; }

		IList<IAirport> Airports { get; set; }

        IList<IItinerary> SortedSearchResults { get; }
    }

    public class AppStateSnapshot : IAppStateSnapshot
    {
        public bool SearchInProgress { get; set; }

        public SortOrder SortOrder { get; set; }

        public ISearchCriteriaSnapshot SearchCriteria { get; set; }

		public IItinerarySnapshot[] SearchResults { get; set; }

		public IItinerarySnapshot[] Shortlist { get; set; }

		public IAirportSnapshot[] Airports { get; set; }
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

        public SortOrder SortOrder
        {
            get => Read<SortOrder>(nameof(SortOrder));
            set => Write(nameof(SortOrder), value);
        }

        public ISearchCriteria SearchCriteria
        {
            get => Read<ISearchCriteria>(nameof(SearchCriteria));
            set => Write(nameof(SearchCriteria), value);
        }

        public IList<IItinerary> SearchResults
        {
            get => Read<IList<IItinerary>>(nameof(SearchResults));
            set => Write(nameof(SearchResults), value);
        }

        public IList<IItinerary> SortedSearchResults => Read<IList<IItinerary>>(nameof(SortedSearchResults));

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

        public void AddToShortlist(IItinerarySnapshot itinerary)
        {
            (Target as dynamic).AddToShortlist(itinerary);
        }

        public void SetSortOrder(SortOrder sortOrder)
        {
            (Target as dynamic).SetSortOrder(sortOrder);
        }

        public void RemoveFromShortlist(IItinerarySnapshot itinerary)
        {
            (Target as dynamic).RemoveFromShortlist(itinerary);
        }

        public void BeginAirportFetch()
        {
            (Target as dynamic).BeginAirportFetch();
        }

        public void EndAirportFetch(IAirportSnapshot[] airports)
        {
            (Target as dynamic).EndAirportFetch(airports);
        }

        public void BeginItinerarySearch()
        {
            (Target as dynamic).BeginItinerarySearch();
        }

        public void EndItinerarySearch(IItinerarySnapshot[] itineraries)
        {
            (Target as dynamic).EndItinerarySearch(itineraries);
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
