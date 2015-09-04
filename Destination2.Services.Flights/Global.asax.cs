using Destination2.Services.Flights.Business.Startup;
using System;

namespace Destination2.Services.Flights
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            InitializeService.Initialize();
        }      

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }      

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}