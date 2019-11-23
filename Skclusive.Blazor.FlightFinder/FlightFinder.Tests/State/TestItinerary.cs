using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using System;
using Skclusive.Blazor.FlightFinder.Models;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.Tests
{
    public class TestItinerary
    {
        [Fact]
        public void TestCreate()
        {
            var today = DateTime.Now.Date;

            var itinerary = ItineraryType.Create(new ItinerarySnapshot
            {
                Id = 1,

                Outbound = new FlightSegmentSnapshot
                {
                    Airline = "British Airways",

                    FromAirportCode = "LHR",

                    ToAirportCode = "SEA",

                    DepartureTime = today,

                    ArrivalTime = today.AddDays(1),

                    DurationHours = 5,

                    TicketClass = TicketClass.Business
                },

                Return = new FlightSegmentSnapshot
                {
                    Airline = "Emirates",

                    FromAirportCode = "SEA",

                    ToAirportCode = "LHR",

                    DepartureTime = today.AddDays(7),

                    ArrivalTime = today.AddDays(8),

                    DurationHours = 6,

                    TicketClass = TicketClass.Economy
                },

                Price = 551.5M
            });

            Assert.Equal("British Airways", itinerary.Outbound.Airline);

            Assert.Equal("Emirates", itinerary.Return.Airline);

            Assert.Equal(11, itinerary.TotalDurationHours);

            Assert.Equal(551.5M, itinerary.Price);

            Assert.Equal("Multiple airlines", itinerary.AirlineName);
        }
    }
}
