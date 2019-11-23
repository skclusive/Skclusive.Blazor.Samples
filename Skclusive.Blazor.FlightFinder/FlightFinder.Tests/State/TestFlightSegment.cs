using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using System;
using Skclusive.Blazor.FlightFinder.Models;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.Tests
{
    public class TestFlightSegment
    {
        [Fact]
        public void TestCreate()
        {
            var today = DateTime.Now.Date;

            var flightSegment = FlightSegmentType.Create(new FlightSegmentSnapshot
            {
                Airline =  "British Airways",

                FromAirportCode = "LHR",

                ToAirportCode = "SEA",

                DepartureTime = today,

                ArrivalTime = today.AddDays(7),

                DurationHours = 5,

                TicketClass = TicketClass.Business
            });

            Assert.Equal("British Airways", flightSegment.Airline);

            Assert.Equal("LHR", flightSegment.FromAirportCode);

            Assert.Equal("SEA", flightSegment.ToAirportCode);

            Assert.Equal(today, flightSegment.DepartureTime);

            Assert.Equal(today.AddDays(7), flightSegment.ArrivalTime);

            Assert.Equal(5, flightSegment.DurationHours);

            Assert.Equal(TicketClass.Business, flightSegment.TicketClass);
        }
    }
}
