using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destination2.WebUi.Search.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [AcceptVerbs("POST")]
        public ActionResult ProcessSearchFormInput()
        {
            // this method works out what the search type is.
            // from here we can then work out how we do the search.

            // eg hit a web service to trigger the search off
            // this then returns whatever we need for a place wait page then it will pulse to check if the page is loaded yet
            
            return View();
        }
    }
}