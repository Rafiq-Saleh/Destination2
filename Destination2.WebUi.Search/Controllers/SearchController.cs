
using Destination2.WebUi.Search.Business;
using Destination2.WebUi.Search.ServiceFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Destination2.WebUi.Search.Models;
namespace Destination2.WebUi.Search.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Search(SearchForm model)
        {
            string  select = model.DepartureAirport;
             
            return View("Search");
        }

        public ActionResult Search()
        {
            SearchForm sf = new SearchForm();

            List<SelectListItem> itemes = new List<SelectListItem>();
            itemes.Add(new SelectListItem
            {
                Text = "LONDON",
                Value = "LON"
            });
            itemes.Add(new SelectListItem
            {
                Text = "MANCHSTER",
                Value = "MAN",
                Selected = true
            });
            itemes.Add(new SelectListItem
            {
                Text = "LIVERPOOL",
                Value = "LIV"
            });
        

            sf.AirportList = itemes;
            sf.AirportList2 = itemes;
            return View(sf);
        }
        [AcceptVerbs("POST")]
        public ActionResult ProcessSearchFormInput()
        {
            // passed in here will the a nice big search object

            // this method works out what the search type is.
            // from here we can then work out how we do the search.

            // for now we are going to pretend it is a package search
            // this call will prep the search           
            FlightServiceClient flightServiceClient = new FlightServiceClient();
            var flightSearchResult = flightServiceClient.StartSearch(new FlightSearch
            {
                IsPackage = true,
                SearchType = "Package"
            });

            // save this into session
            SessionService sessionService = new SessionService();
            sessionService.SetItem(SessionEnum.FlightSearch, flightSearchResult.FlightSearchId.ToString(), flightSearchResult);

            // this will change depending on the search type
            return Redirect("search/package-flight-wait/?id=" + flightSearchResult.FlightSearchId);
        }
        [AcceptVerbs("POST")]
        public ActionResult ProcessFlightSearch(string IsPackage, string SearchType, string DepartureAirportID, string DestinationAirportID, string DepartureDate, string ReturnDate,
                                                   string NumberOfAdults, string NumberOfChildren, string NumberOfInfants, string CabinClassID, string DirectFlightsOnly)
        {
            FlightSearch flightSearch = new FlightSearch();
            flightSearch.IsPackage = Convert.ToBoolean(IsPackage);
            flightSearch.SearchType = SearchType;
            flightSearch.DepartureAirportID = Convert.ToInt16(DepartureAirportID);
            flightSearch.DestinationAirportID = Convert.ToInt16(DestinationAirportID);
            flightSearch.DepartureDate = Convert.ToDateTime(DepartureDate);
            flightSearch.ReturnDate = Convert.ToDateTime(ReturnDate);
            flightSearch.NumberOfAdults = Convert.ToInt16(NumberOfAdults);
            flightSearch.NumberOfChildren = Convert.ToInt16(NumberOfChildren);
            flightSearch.NumberOfInfants = Convert.ToInt16(NumberOfInfants);
            flightSearch.CabinClassID = Convert.ToInt16(CabinClassID);
            flightSearch.DirectFlightsOnly = Convert.ToBoolean(DirectFlightsOnly);

            // for now we are going to pretend it is a package search
            // this call will prep the search           
            FlightServiceClient flightServiceClient = new FlightServiceClient();
            var flightSearchResult = flightServiceClient.StartSearch(flightSearch);

            // save this into session
            SessionService sessionService = new SessionService();
            sessionService.SetItem(SessionEnum.FlightSearch, flightSearchResult.FlightSearchId.ToString(), flightSearchResult);

            // this will change depending on the search type
            return Redirect("search/package-flight-wait/?id=" + flightSearchResult.FlightSearchId);
        }
    }
}
