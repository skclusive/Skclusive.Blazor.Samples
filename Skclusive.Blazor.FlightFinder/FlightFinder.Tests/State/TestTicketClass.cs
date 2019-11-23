using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.Blazor.FlightFinder.Models;
using static Skclusive.Blazor.FlightFinder.Models.AppTypes;

namespace Skclusive.Blazor.FlightFinder.Tests
{
    public class TestTicketClass
    {
        [Fact]
        public void TestCreate()
        {
            var ticketClass = TicketClassType.Create(TicketClass.Business);

            Assert.Equal(TicketClass.Business, ticketClass);
        }
    }
}
