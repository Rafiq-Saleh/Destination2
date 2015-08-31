using Destination2.Services.Flights.Entities;
using System.ServiceModel;

namespace Destination2.Services.Flights
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFlightService" in both code and config file together.
    [ServiceContract]
    public interface IFlightService
    {
        [OperationContract]
        FlightSearchResult StartSearch(FlightSearch flightSearch);

        [OperationContract]
        FlightSearchResult RetriveSearch(int id);
    }
}
