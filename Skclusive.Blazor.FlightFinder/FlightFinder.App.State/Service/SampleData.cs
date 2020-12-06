using System;
using System.Collections.Generic;
using System.Linq;
using Skclusive.Mobx.StateTree;

namespace Skclusive.FlightFinder.App.State
{
	public class SampleData
	{
		public readonly static AirportSnapshot[] Airports = new[]
		{
			new AirportSnapshot { Code = "ATL", DisplayName = "Hartsfield–Jackson Atlanta International" },
			new AirportSnapshot { Code = "PEK", DisplayName = "Beijing Capital International" },
			new AirportSnapshot { Code = "DXB", DisplayName = "Dubai International" },
			new AirportSnapshot { Code = "LAX", DisplayName = "Los Angeles International" },
			new AirportSnapshot { Code = "HND", DisplayName = "Tokyo Haneda International" },
			new AirportSnapshot { Code = "ORD", DisplayName = "O'Hare International" },
			new AirportSnapshot { Code = "LHR", DisplayName = "London Heathrow" },
			new AirportSnapshot { Code = "HKG", DisplayName = "Hong Kong International" },
			new AirportSnapshot { Code = "PVG", DisplayName = "Shanghai Pudong International" },
			new AirportSnapshot { Code = "CDG", DisplayName = "Charles de Gaulle" },
			new AirportSnapshot { Code = "DFW", DisplayName = "Dallas/Fort Worth International" },
			new AirportSnapshot { Code = "AMS", DisplayName = "Amsterdam Schiphol" },
			new AirportSnapshot { Code = "FRA", DisplayName = "Frankfurt" },
			new AirportSnapshot { Code = "IST", DisplayName = "Istanbul Atatürk" },
			new AirportSnapshot { Code = "CAN", DisplayName = "Guangzhou Baiyun International" },
			new AirportSnapshot { Code = "JFK", DisplayName = "John F. Kennedy International" },
			new AirportSnapshot { Code = "SIN", DisplayName = "Singapore Changi" },
			new AirportSnapshot { Code = "DEN", DisplayName = "Denver International" },
			new AirportSnapshot { Code = "ICN", DisplayName = "Seoul Incheon International" },
			new AirportSnapshot { Code = "BKK", DisplayName = "Suvarnabhumi" },
			new AirportSnapshot { Code = "DEL", DisplayName = "Indira Gandhi International" },
			new AirportSnapshot { Code = "CGK", DisplayName = "Soekarno–Hatta International" },
			new AirportSnapshot { Code = "SFO", DisplayName = "San Francisco International" },
			new AirportSnapshot { Code = "KUL", DisplayName = "Kuala Lumpur International" },
			new AirportSnapshot { Code = "MAD", DisplayName = "Madrid Barajas" },
			new AirportSnapshot { Code = "LAS", DisplayName = "McCarran International" },
			new AirportSnapshot { Code = "CTU", DisplayName = "Chengdu Shuangliu International" },
			new AirportSnapshot { Code = "SEA", DisplayName = "Seattle-Tacoma International" },
			new AirportSnapshot { Code = "BOM", DisplayName = "Chhatrapati Shivaji International" },
			new AirportSnapshot { Code = "MIA", DisplayName = "Miami International" },
			new AirportSnapshot { Code = "CLT", DisplayName = "Charlotte Douglas International" },
			new AirportSnapshot { Code = "YYZ", DisplayName = "Toronto Pearson International" },
			new AirportSnapshot { Code = "BCN", DisplayName = "Barcelona–El Prat" },
			new AirportSnapshot { Code = "PHX", DisplayName = "Phoenix Sky Harbor International" },
			new AirportSnapshot { Code = "LGW", DisplayName = "London Gatwick" },
			new AirportSnapshot { Code = "TPE", DisplayName = "Taiwan Taoyuan International" },
			new AirportSnapshot { Code = "MUC", DisplayName = "Munich" },
			new AirportSnapshot { Code = "SYD", DisplayName = "Sydney Kingsford-Smith" },
			new AirportSnapshot { Code = "KMG", DisplayName = "Kunming Changshui International" },
			new AirportSnapshot { Code = "SZX", DisplayName = "Shenzhen Bao'an International" },
			new AirportSnapshot { Code = "MCO", DisplayName = "Orlando International" },
			new AirportSnapshot { Code = "FCO", DisplayName = "Leonardo da Vinci–Fiumicino" },
			new AirportSnapshot { Code = "IAH", DisplayName = "George Bush Intercontinental" },
			new AirportSnapshot { Code = "MEX", DisplayName = "Benito Juárez International" },
			new AirportSnapshot { Code = "SHA", DisplayName = "Shanghai Hongqiao International" },
			new AirportSnapshot { Code = "EWR", DisplayName = "Newark Liberty International" },
			new AirportSnapshot { Code = "MNL", DisplayName = "Ninoy Aquino International" },
			new AirportSnapshot { Code = "NRT", DisplayName = "Narita International" },
			new AirportSnapshot { Code = "MSP", DisplayName = "Minneapolis/St Paul International" },
			new AirportSnapshot { Code = "DOH", DisplayName = "Hamad International" },
		};

		public readonly static string[] Airlines = new[]
		{
			"American Airlines",
			"British Airways",
			"Delta",
			"Emirates",
			"Etihad",
			"JetBlue",
			"KLM",
			"Singapore Airways",
			"Qantas",
			"Virgin Atlantic",
		};

        private static int IdGenerator = 1;

        public static IEnumerable<ItinerarySnapshot> Search(ISearchCriteria criteria)
		{
            var rng = new Random();
			return Enumerable.Range(0, rng.Next(1, 5)).Select(_ => new ItinerarySnapshot
			{
                Id = IdGenerator++,

				Price = rng.Next(100, 2000),

				Outbound = new FlightSegmentSnapshot
				{
					Airline = RandomAirline(),

                    FromAirportCode = criteria.FromAirport,

                    ToAirportCode = criteria.ToAirport,

                    DepartureTime = criteria.OutboundDate.AddHours(rng.Next(24)).AddMinutes(5 * rng.Next(12)),

                    ArrivalTime = criteria.OutboundDate.AddHours(rng.Next(24)).AddMinutes(5 * rng.Next(12)),

                    DurationHours = 2 + rng.Next(10),

                    TicketClass = criteria.TicketClass
				},
				Return = new FlightSegmentSnapshot
				{
					Airline = RandomAirline(),

                    FromAirportCode = criteria.ToAirport,

                    ToAirportCode = criteria.FromAirport,

                    DepartureTime = criteria.ReturnDate.AddHours(rng.Next(24)).AddMinutes(5 * rng.Next(12)),

                    ArrivalTime = criteria.ReturnDate.AddHours(rng.Next(24)).AddMinutes(5 * rng.Next(12)),

                    DurationHours = 2 + rng.Next(10),

                    TicketClass = criteria.TicketClass
				},
			});

            string RandomAirline() => Airlines[rng.Next(Airlines.Length)];
        }
    }
}
