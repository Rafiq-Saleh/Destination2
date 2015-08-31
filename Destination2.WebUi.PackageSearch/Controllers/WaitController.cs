using Destination2.WebUi.PackageSearch.Models;
using Destination2.WebUi.PackageSearch.ServiceFlights;
using System;
using System.Threading;
using System.Web.Mvc;

namespace Destination2.WebUi.PackageSearch.Controllers
{
    public class WaitController : Controller
    {
        // GET: Wait
        public ActionResult FlightWait(int id)
        {
            // Now Retrive the search
            FlightServiceClient flightServiceClient = new FlightServiceClient();
            var flightSearchResult =  flightServiceClient.RetriveSearch(id);

            // display anything we need on this please wait page

            return View(new FlightWaitViewModel {Id = id });
        }

        [HttpPost]
        public ActionResult FlightSearchStart(int id)
        {
            Thread.Sleep(5000);
            return Json(new { success = true });
        }
    }
}