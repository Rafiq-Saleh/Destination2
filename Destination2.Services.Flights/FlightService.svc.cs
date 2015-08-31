using Destination2.Services.Flights.Business;
using Destination2.Services.Flights.Business.Search;
using Destination2.Services.Flights.Data;
using Destination2.Services.Flights.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Destination2.Services.Flights
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FlightService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FlightService.svc or FlightService.svc.cs at the Solution Explorer and start debugging.
    public class FlightService : IFlightService
    {
        private ISessionService sessionService;
        private ISearchRepository searchRepository;
        private ISearch search;

        public FlightService()
        {
            sessionService = new SessionService();
            searchRepository = new SearchRepository(ConfigurationManager.ConnectionStrings["Destination2"].ConnectionString);
            search = new Search(sessionService, searchRepository);
        }

        public FlightSearchResult StartSearch(FlightSearch flightSearch)
        {
            return search.StartSearch(flightSearch);
        }

        public FlightSearchResult RetriveSearch(int id)
        {
            return search.RetriveSearch(id);
        }
    }
}
