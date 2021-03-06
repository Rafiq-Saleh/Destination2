﻿using Destination2.Services.Flights.AirService;
using Destination2.Services.Flights.Business.Supplier;
using Destination2.Services.Flights.Data;
using Destination2.Services.Flights.Entities;
using System;

namespace Destination2.Services.Flights.Business.Search
{
    internal interface ISearchService
    {
        FlightSearchResult StartSearch(FlightSearch flightSearch);
        FlightSearch RetriveSearch(int id);
        FlightSearchResult PerformSearch(FlightSearch flightSearch, int searchId);
    }

    internal class SearchService : ISearchService
    {
        private readonly ISearchRepository searchRepository;
        private readonly IGatewayService gatewayService;

        public SearchService(ISearchRepository searchRepository, IGatewayService gatewayService)
        {           
            this.searchRepository = searchRepository;
            this.gatewayService = gatewayService;
        }

        public FlightSearchResult PerformSearch(FlightSearch flightSearch, int searchId)
        {
            FlightSearchResult flightSearchResult = new FlightSearchResult();            
            AirServiceSoapClient airServiceSoapClient = new AirServiceSoapClient();            

            var authenticateResponse = gatewayService.GetToken();            

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
            if (validateFlightSearch(flightSearch))
            {
                //alert user of the error
                return null;
            }
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

        private bool validateFlightSearch(FlightSearch flightSearch)
        {
           // string error = "";
            if (flightSearch.DepartureDate <= DateTime.Now)
            {
               // error += "Please select a valid departure date";
                return false;
            }
            if (flightSearch.ReturnDate <= flightSearch.DepartureDate)
            {
               // error += "Please select a valid return date";
                return false;
            }
            // add other validation if necessary
            return true;
        }

        public FlightSearch RetriveSearch(int id)
        {
            // here we want to rebuild the object used if the session has expired

            return null;
        }
    }
}