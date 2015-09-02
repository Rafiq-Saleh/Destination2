namespace Destination2.Services.Flights.Entities
{
    public class Settings
    {
        public DataBaseSettings DataBaseSettings { get; set;}
        public GatewaySettings GatewaySettings { get; set; }
    }

    public class DataBaseSettings
    {
        public string MainConnectionString { get; set; }
    }

    public class GatewaySettings
    {
        public string Application { get; set; }
        public string BranchCode { get; set; }
        public int BranchID { get; set;}
        public string UserName { get; set; }
        public string Password { get; set; }
    }    
}