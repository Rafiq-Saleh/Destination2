using Destination2.Services.Flights.Data;
using Destination2.Services.Flights.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Destination2.Services.Flights.Business.Search
{
    internal interface ISearch
    {
        FlightSearchResult StartSearch(FlightSearch flightSearch);
        FlightSearchResult RetriveSearch(int id);
    }

    internal class Search : ISearch
    {
        private readonly ISessionService sessionService;
        private readonly ISearchRepository searchRepository;

        public Search(ISessionService sessionService, ISearchRepository searchRepository)
        {
            this.sessionService = sessionService;
            this.searchRepository = searchRepository;
        }


        public void PerformSearch(int id)
        {

        }


        public FlightSearchResult StartSearch(FlightSearch flightSearch)
        {
            // Validate the search

            // save all to the database that is needed this included what the customer searched for so we can report on it later
            var searchId = searchRepository.SearchFlightStart(flightSearch);

            // create our object to return
            FlightSearchResult flightSearchResult = new FlightSearchResult
            {
                FlightSearchId = searchId,
                FlightSearch = flightSearch
            };

            // return anything we need for the please wait page - currently unknown apart from the searh id


            // save the flight search result in session as will be easier to get the data later on
            sessionService.SetItem(SessionEnum.FlightSearch, searchId.ToString(), flightSearchResult);

            // return as we are done here
            return flightSearchResult;
        }

        public FlightSearchResult RetriveSearch(int id)
        {
            // see if the search is in the session
            if (sessionService.ItemExists(SessionEnum.FlightSearch, id.ToString()))
                return sessionService.GetItem<FlightSearchResult>(SessionEnum.FlightSearch, id.ToString());

            // session has expired here however we have the id which means we can have a look in the database
            // what they have searched for and try again
            // however for now I am going to return null 

            return null;
        }
    }
}