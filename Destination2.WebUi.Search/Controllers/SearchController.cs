
using Destination2.WebUi.Search.Business;
using Destination2.WebUi.Search.ServiceFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Destination2.WebUi.Search.Entities;

namespace Destination2.WebUi.Search.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        // passed in here will the a nice big Destination2.WebUi.Search.Entities object
        public ActionResult index(SearchForm model)
        {
            return View(model);
        }
        public ActionResult ProcessSearchFormInput(SearchForm model)
        {

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

        public ActionResult FlightSearch()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult ProcessFlightSearch(FlightSearch flightSearch)
        {
            if (ModelState.IsValid)
            {
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
            else
            {
                return View("flightSearch");
            }
        
        }
    }
}