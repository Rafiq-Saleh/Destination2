using System;
using System.Web.Mvc;

namespace Destination2.WebUi.PackageSearch.Controllers
{
    public class WaitController : Controller
    {
        // GET: Wait
        public ActionResult FlightWait(Guid searchGuid)
        {
            return View();
        }
    }
}