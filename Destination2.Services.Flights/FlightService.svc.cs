using Destination2.Services.Flights.Business;
using Destination2.Services.Flights.Business.Cache;
using Destination2.Services.Flights.Business.Search;
using Destination2.Services.Flights.Business.Startup;
using Destination2.Services.Flights.Business.Supplier;
using Destination2.Services.Flights.Data;
using Destination2.Services.Flights.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Destination2.Services.Flights
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FlightService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FlightService.svc or FlightService.svc.cs at the Solution Explorer and start debugging.
    public class FlightService : IFlightService
    {
        // data
        private ISearchRepository searchRepository;

        // business
        private ISearchService search;
        private ICacheService<CacheServiceEnum> cacheService;
        private IGatewayService gatewayService;

        public FlightService()
        {   
            // data       
            searchRepository = new SearchRepository(ConfigurationManager.ConnectionStrings["Destination2"].ConnectionString);

            // business
            cacheService = new CacheService(MemoryCache.Default);
            gatewayService = new GatewayService(InitializeService.Settings, cacheService);
            search = new SearchService(searchRepository, gatewayService);
        }

        public FlightSearchResult StartSearch(FlightSearch flightSearch)
        {
            return search.StartSearch(flightSearch);
        }

        public FlightSearch RetriveSearch(int id)
        {
            return search.RetriveSearch(id);
        }

        public FlightSearchResult PerformSearch(FlightSearch flightSearch, int id)
        {
            return search.PerformSearch(flightSearch, id);
        }
    }
}
