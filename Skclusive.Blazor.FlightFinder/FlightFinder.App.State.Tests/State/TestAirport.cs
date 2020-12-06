using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.FlightFinder.App.State;
using static Skclusive.FlightFinder.App.State.AppTypes;

namespace Skclusive.FlightFinder.App.State.Tests
{
    public class TestAirport
    {
        [Fact]
        public void TestCreate()
        {
            var airport = AirportType.Create(new AirportSnapshot { Code = "PEK", DisplayName = "Beijing Capital International" });

            Assert.Equal("PEK", airport.Code);

            Assert.Equal("Beijing Capital International", airport.DisplayName);
        }
    }
}
