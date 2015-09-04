using System.Web.Mvc;

namespace Destination2.WebUi
{
    public class SearchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Search";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Search_default",
                "Search",
                new { controller = "Search", action = "ProcessSearchFormInput", id = UrlParameter.Optional, area = "Search" },
                new[] { "Destination2.WebUi.Search.Controllers" }
            );

            context.MapRoute(
                "PackageSerarchWaitFlight",
                "Search/Package-Flight-Wait",
                new { controller = "Wait", action = "FlightWait", id = UrlParameter.Optional, area = "Search" },
                new[] { "Destination2.WebUi.Search.Controllers" }
            );

            context.MapRoute(
                "PackageSerarchWaitFlightSearchStart",
                "Search/Package-Flight-Start",
                new { controller = "Wait", action = "FlightSearchStart", id = UrlParameter.Optional, area = "Search" },
                new[] { "Destination2.WebUi.Search.Controllers" }
            );

            context.MapRoute(
               "PackageSearchWaitFlightSearchStart",
               "Search/Package-Flight-Results",
               new { controller = "Results", action = "FlightResults", id = UrlParameter.Optional, area = "Search" },
               new[] { "Destination2.WebUi.Search.Controllers" }
           );
        }
    }
}