using System.Web.Mvc;

namespace Destination2.WebUi
{
    public class HomeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Home_default",
                "",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, area= "Home" },
                new[] { "Destination2.WebUi.Home.Controllers" }
            );
        }
    }
}