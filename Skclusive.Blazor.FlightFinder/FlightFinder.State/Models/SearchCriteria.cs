using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    public interface ISearchCriteria
    {
        string FromAirport { get; set; }

        string ToAirport { get; set; }

        DateTime OutboundDate { get; set; }

        DateTime ReturnDate { get; set; }

        TicketClass TicketClass { get; set; }
    }

    public class SearchCriteria : ISearchCriteria
    {
        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime OutboundDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public TicketClass TicketClass { get; set; }
    }
}
