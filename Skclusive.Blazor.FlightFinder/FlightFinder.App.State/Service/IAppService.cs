using System.Threading.Tasks;

namespace Skclusive.FlightFinder.App.State
{
    public interface IAppService
    {
        Task LoadAirportsAsync();

        Task SearchItinerariesAsync(ISearchCriteria searchCriteria);
    }
}
