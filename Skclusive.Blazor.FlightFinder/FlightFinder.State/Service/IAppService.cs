using System.Threading.Tasks;
using Skclusive.Blazor.FlightFinder.Models;

namespace Skclusive.Blazor.FlightFinder.Service
{
    public interface IAppService
    {
        Task LoadAirportsAsync();

        Task SearchItinerariesAsync(ISearchCriteria searchCriteria);
    }
}
