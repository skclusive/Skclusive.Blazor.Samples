using System.Linq;
using System.Threading.Tasks;
using Skclusive.Blazor.FlightFinder.Models;

namespace Skclusive.Blazor.FlightFinder.Service
{
    internal class AppService : IAppService
    {
        private IAppState appState;

        public AppService(IAppState appState)
        {
            this.appState = appState;
        }

        public async Task LoadAirportsAsync()
        {
            appState.BeginAirportFetch();

            await Task.Delay(1000);

            appState.EndAirportFetch(SampleData.Airports.ToArray());
        }

        public async Task SearchItinerariesAsync(ISearchCriteria searchCriteria)
        {
            appState.BeginItinerarySearch();

            await Task.Delay(1000);

            var itineraries = SampleData.Search(searchCriteria);

            appState.EndItinerarySearch(itineraries.ToArray());
        }
    }
}
