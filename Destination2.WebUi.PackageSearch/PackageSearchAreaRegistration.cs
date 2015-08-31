using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destination2.WebUi
{
    public class PackageSearchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PackageSearch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PackageSerarchWaitFlight",
                "Search/Package-Flight-Wait",
                new { controller = "Wait", action = "FlightWait", id = UrlParameter.Optional, area = "PackageSearch" },
                new[] { "Destination2.WebUi.PackageSearch.Controllers" }
            );

            context.MapRoute(
                "PackageSerarchWaitFlightSearchStart",
                "Search/Package-Flight-Start",
                new { controller = "Wait", action = "FlightSearchStart", id = UrlParameter.Optional, area = "PackageSearch" },
                new[] { "Destination2.WebUi.PackageSearch.Controllers" }
            );
        }
    }
}