using System.Collections.Generic;
using Skclusive.Mobx.StateTree;
using Xunit;
using Skclusive.FlightFinder.App.State;
using static Skclusive.FlightFinder.App.State.AppTypes;

namespace Skclusive.FlightFinder.App.State.Tests
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
