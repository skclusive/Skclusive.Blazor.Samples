using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.FlightFinder.App.State;
using System;
using static Skclusive.FlightFinder.App.State.AppTypes;

namespace Skclusive.FlightFinder.App.State.Tests
{
    public class TestAppState
    {
        [Fact]
        public void TestCreate()
        {
            var today = DateTime.Now.Date;

            var appState = AppStateType.Create(new AppStateSnapshot
            {
                SearchInProgress = true,

                SortOrder = SortOrder.Price,

                SearchCriteria = new SearchCriteriaSnapshot()
                {
                    FromAirport = "LHR",

                    ToAirport = "SEA",

                    OutboundDate = today,

                    ReturnDate = today.AddDays(7)
                }
            });

            Assert.True(appState.SearchInProgress);

            Assert.NotNull(appState.SearchCriteria);

            Assert.Equal("LHR", appState.SearchCriteria.FromAirport);

            Assert.Equal("SEA", appState.SearchCriteria.ToAirport);

            Assert.Equal(today, appState.SearchCriteria.OutboundDate);

            Assert.Equal(today.AddDays(7), appState.SearchCriteria.ReturnDate);
        }
    }
}
