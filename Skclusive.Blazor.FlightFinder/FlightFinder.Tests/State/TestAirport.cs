using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.Blazor.FlightFinder.Models;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.Tests
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
