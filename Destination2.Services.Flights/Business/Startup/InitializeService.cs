using Destination2.Services.Flights.Business.Search;
using Destination2.Services.Flights.Entities;
using System.Configuration;

namespace Destination2.Services.Flights.Business.Startup
{
    internal class InitializeService
    {
        internal static Settings Settings;
        private static Settings _settings;     

        internal static void Initialize()
        {
            if (Settings != null)
                return;

            _settings = new Settings();

            GetDatabaseSettings();
            GetGatewaySettings();

            Settings = _settings;
          
        }

        private static void GetDatabaseSettings()
        {
            _settings.DataBaseSettings = new DataBaseSettings
            {
                MainConnectionString = ConfigurationManager.ConnectionStrings["Destination2"].ConnectionString
            };
        }

        private static void GetGatewaySettings()
        {
            _settings.GatewaySettings = new GatewaySettings
            {
                Application = ConfigurationManager.AppSettings["GatewayApplication"],
                BranchCode = ConfigurationManager.AppSettings["GatewayBranchCode"],
                BranchID = int.Parse(ConfigurationManager.AppSettings["GatewayBranchID"]),
                UserName = ConfigurationManager.AppSettings["GatewayUserName"],
                Password = ConfigurationManager.AppSettings["GatewayPassword"]
            };
        }
    }
}