using Destination2.Services.Flights.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Destination2.Services.Flights.Business.Search
{
    internal class Search
    {
        private readonly ISessionService sessionService;

        public Search(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }


        public void PerformSearch(FlightSearch flightSearch)
        {
            
        }


        public void StartSearch(FlightSearch flightSearch)
        {
            // validate the search
            

            // trigger the search
            

            // return anything we need for the please wait page - currently unknown


        }
    }
}