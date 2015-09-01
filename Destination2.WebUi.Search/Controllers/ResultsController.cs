using Destination2.WebUi.Search.Business;
using Destination2.WebUi.Search.Models;
using Destination2.WebUi.Search.ServiceFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destination2.WebUi.Search.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult FlightResults(int id)
        {
            SessionService sessionService = new SessionService();
            if (!sessionService.ItemExists(SessionEnum.FlightSearch, id.ToString()))
            {
                // ah error has happend the session has gone
                // now we could be clever here and get the search back out of the database and restart it   
                throw new Exception("Session Gone");
            }

            var flightSearchResult = sessionService.GetItem<FlightSearchResult>(SessionEnum.FlightSearch, id.ToString());

            
            return View(new FlightResultViewModel
            {
                Message = flightSearchResult.ErrorMessage
            });
        }
    }
}