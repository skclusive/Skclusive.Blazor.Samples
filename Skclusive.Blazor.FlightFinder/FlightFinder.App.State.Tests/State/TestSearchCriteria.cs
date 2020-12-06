using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using System;
using Skclusive.FlightFinder.App.State;
using static Skclusive.FlightFinder.App.State.AppTypes;

namespace Skclusive.FlightFinder.App.State.Tests
{
    public class TestSearchCriteria
    {
        [Fact]
        public void TestCreate()
        {
            var today = DateTime.Now.Date;

            var searchCriteria = SearchCriteriaType.Create(new SearchCriteriaSnapshot
            {
                FromAirport = "LHR",

                ToAirport = "SEA",

                OutboundDate = today,

                ReturnDate = today.AddDays(7)
            });

            Assert.Equal("LHR", searchCriteria.FromAirport);

            Assert.Equal("SEA", searchCriteria.ToAirport);

            Assert.Equal(today, searchCriteria.OutboundDate);

            Assert.Equal(today.AddDays(7), searchCriteria.ReturnDate);
        }
    }
}
