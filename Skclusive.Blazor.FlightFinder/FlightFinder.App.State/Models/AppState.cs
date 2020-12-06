using System;
using System.Linq;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using System.Collections.Generic;

namespace Skclusive.FlightFinder.App.State
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

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<IAppStateSnapshot, IAppState> AppStateType = Types.Late("LateAppStateType", () => Types.
            Object<IAppStateSnapshot, IAppState>("AppStateType")
            .Proxy(x => new AppStateProxy(x))
            .Snapshot(() => new AppStateSnapshot())
            .Mutable(o => o.SearchInProgress, Types.Boolean)
            .Mutable(o => o.Airports, AirportListType)
            .Mutable(o => o.SearchResults, ItineraryListType)
            .Mutable(o => o.Shortlist, ItineraryListType)
            .Mutable(o => o.SearchCriteria, SearchCriteriaType)
            .Mutable(o => o.SortOrder, Types.Optional(SortOderType, SortOrder.Price))
            .View(o => o.SortedSearchResults, ItineraryListType, (o) => o.SortOrder == SortOrder.Price
            ? o.SearchResults.OrderBy(x => x.Price).ToList()
            : o.SearchResults.OrderBy(x => x.TotalDurationHours).ToList())
            .Action<IItinerarySnapshot>((o) => o.AddToShortlist(null), (o, itinerary) => o.Shortlist.Add(ItineraryType.Create(itinerary)))
            .Action<IItinerarySnapshot>((o) => o.RemoveFromShortlist(null), (o, itinerary) => o.Shortlist.Remove(o.Shortlist.First(it => it.Id == itinerary.Id)))
            .Action((o) => o.BeginAirportFetch(), (o) => o.SearchInProgress = true)
            .Action<SortOrder>((o) => o.SetSortOrder(SortOrder.Price), (o, sortOrder) => o.SortOrder = sortOrder)
            .Action<IAirportSnapshot[]>((o) => o.EndAirportFetch(null), (o, airports) =>
            {
                o.SearchInProgress = false;
                foreach(var airport in airports)
                o.Airports.Add(AirportType.Create(airport));
            })
            .Action((o) => o.BeginItinerarySearch(), (o) => o.SearchInProgress = true)
            .Action<IItinerarySnapshot[]>((o) => o.EndItinerarySearch(null), (o, itineraries) =>
            {
                o.SearchInProgress = false;
                o.SearchResults.Clear();
                foreach (var itinerary in itineraries)
                o.SearchResults.Add(ItineraryType.Create(itinerary));
            }));
    }
}
