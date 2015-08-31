using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Destination2.WebUi.PackageSearch
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
                "FlightWait",
                new { controller = "Wait", action = "Index", id = UrlParameter.Optional, area = "Home" },
                new[] { "Destination2.WebUi.PackageSearch.Controllers" }
            );
        }
    }
}