using Destination2.Services.Flights.AirService;
using Destination2.Services.Flights.Data;
using Destination2.Services.Flights.DirectoryService;
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
        FlightSearch RetriveSearch(int id);
        FlightSearchResult PerformSearch(FlightSearch flightSearch, int searchId);
    }

    internal class Search : ISearch
    {
        private readonly ISearchRepository searchRepository;

        public Search(ISearchRepository searchRepository)
        {           
            this.searchRepository = searchRepository;
        }


        public FlightSearchResult PerformSearch(FlightSearch flightSearch, int searchId)
        {
            FlightSearchResult flightSearchResult = new FlightSearchResult();


            DirectoryServiceSoapClient directoryServiceSoapClient = new DirectoryServiceSoapClient();
            AirServiceSoapClient airServiceSoapClient = new AirServiceSoapClient();
            // again this is very naughty tut tut this should be in a settings file on application start that is read from the webconfig

            // also this gives us a token that is valid for a certain amount of time so we should not requst it over and over again 
            // need to go into own method and cache the thing
            var authenticateResponse = directoryServiceSoapClient.Authenticate(new AuthenticateRequest
            {
                Application = "ExternalAPI",
                BranchCode = "W6886",
                BranchID = 2,
                UserName = "APIUser",
                Password = "holgems68",
                RemoteIPAddress = HttpContext.Current.Request.UserHostAddress
            });

            if (!authenticateResponse.Success)
            {
                flightSearchResult.Success = false;
                flightSearchResult.ErrorMessage = "Could not get token";
                return flightSearchResult;
            }

            // now lets try a search
            var JourneyDetails = new JourneyDetail[]
            {
                new JourneyDetail
                {
                    DepartureDateTime = DateTime.Now.Date.AddDays(30).AddHours(9),
                    DeparturePoint = "LON",
                    DeparturePointIsCity = true,
                    DestinationPoint = "DXB",
                    DestinationPointIsCity = false
                },
                new JourneyDetail {
                     DepartureDateTime = DateTime.Now.Date.AddDays(37).AddHours(9),
                    DeparturePoint = "DXB",
                    DeparturePointIsCity = false,
                    DestinationPoint = "LON",
                    DestinationPointIsCity = true
                }
            };


            var airSearchResult = airServiceSoapClient.Search(new AirService.AuthHeader
            {
                Token = authenticateResponse.Token.Value
            },
            new AirSearch
            {
                CabinClass = CabinClasses.All,
                FareType = FareTypes.All,
                FlexiDays = 0,
                SelectedAirlines = null,
                SessionID = "FlightSearch" + searchId,
                MultipleCabinClasses = new CabinClasses[] { CabinClasses.All }, // change this if we want business etc...
                AdultPaxCount = 2,
                ChildPaxCount = 0,
                ChildAges = null,
                InfantPaxCount = 0,
                JourneyDetails = JourneyDetails,
                SearchType = SearchTypes.Availability,
                SortOrder = SortOrders.Price,
                DirectFlightsOnly = false
            });

            // check if we have results

            // process them into our object

            // apply markup to the flights



            flightSearchResult.Success = true;
            flightSearchResult.ErrorMessage = "There was " + airSearchResult.Results.Result.Length + " results starting at £" + airSearchResult.Results.Result[0].AdultTotal;
            return flightSearchResult;
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

            // return anything we need for the please wait page - currently unknown apart from the search id
                              
            // return as we are done here
            return flightSearchResult;
        }

        public FlightSearch RetriveSearch(int id)
        {
            // here we want to rebuild the object used if the session has expired

            return null;
        }
    }
}