using System;
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
        void SetFromAirport(string fromAirport);

        void SetToAirport(string toAirport);

        void SetOutboundDate(DateTime outboundDate);

        void SetReturnDate(DateTime returnDate);

        void SetTicketClass(TicketClass ticketClass);
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

        public void SetFromAirport(string fromAirport)
        {
            (Target as dynamic).SetFromAirport(fromAirport);
        }

        public void SetToAirport(string toAirport)
        {
            (Target as dynamic).SetToAirport(toAirport);
        }

        public void SetOutboundDate(DateTime outboundDate)
        {
            (Target as dynamic).SetOutboundDate(outboundDate);
        }

        public void SetReturnDate(DateTime returnDate)
        {
            (Target as dynamic).SetReturnDate(returnDate);
        }

        public void SetTicketClass(TicketClass ticketClass)
        {
            (Target as dynamic).SetTicketClass(ticketClass);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<ISearchCriteriaSnapshot, ISearchCriteria> SearchCriteriaType = Types.Late("LateSearchCriteriaType", () => Types.
            Object<ISearchCriteriaSnapshot, ISearchCriteria>("SearchCriteriaType")
            .Proxy(x => new SearchCriteriaProxy(x))
            .Snapshot(() => new SearchCriteriaSnapshot())
            .Mutable(o => o.FromAirport, Types.String)
            .Mutable(o => o.ToAirport, Types.String)
            .Mutable(o => o.OutboundDate, DateTimeType)
            .Mutable(o => o.ReturnDate, DateTimeType)
            .Mutable(o => o.TicketClass, TicketClassType)
            .Action<string>((o) => o.SetFromAirport(null), (o, fromAirport) => o.FromAirport = fromAirport)
            .Action<string>((o) => o.SetToAirport(null), (o, toAirport) => o.ToAirport = toAirport)
            .Action<DateTime>((o) => o.SetOutboundDate(DateTime.MinValue), (o, outboundDate) => o.OutboundDate = outboundDate)
            .Action<DateTime>((o) => o.SetReturnDate(DateTime.MinValue), (o, returnDate) => o.ReturnDate = returnDate)
            .Action<TicketClass>((o) => o.SetTicketClass(TicketClass.Business), (o, ticketClass) => o.TicketClass = ticketClass));
    }
}
