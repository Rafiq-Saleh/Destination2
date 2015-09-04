using Destination2.Services.Flights.Business.Cache;
using Destination2.Services.Flights.DirectoryService;
using Destination2.Services.Flights.Entities;
using System;
using System.Web;

namespace Destination2.Services.Flights.Business.Supplier
{
    public interface IGatewayService
    {
        AuthenticateResponse GetToken();
    }

    public class GatewayService : IGatewayService
    {
        private Settings settings;
        private ICacheService<CacheServiceEnum> cacheService;

        public GatewayService(Settings settings, ICacheService<CacheServiceEnum> cacheService)
        {
            this.settings = settings;
            this.cacheService = cacheService;
        }

        public AuthenticateResponse GetToken()
        {
            AuthenticateResponse authenticateResponse;

            // first see if we have already got a token
            if (cacheService.ItemExists(CacheServiceEnum.GatewayToken))
            {
                authenticateResponse = cacheService.GetItem<AuthenticateResponse>(CacheServiceEnum.GatewayToken);
                // check that it has not expired
                if (authenticateResponse.Expiry > DateTime.Now)
                    return authenticateResponse;
            }

            // get new token
            DirectoryServiceSoapClient directoryServiceSoapClient = new DirectoryServiceSoapClient();
            authenticateResponse = directoryServiceSoapClient.Authenticate(new AuthenticateRequest
            {
                Application = settings.GatewaySettings.Application,
                BranchCode = settings.GatewaySettings.BranchCode,
                BranchID = settings.GatewaySettings.BranchID,
                UserName = settings.GatewaySettings.UserName,
                Password = settings.GatewaySettings.Password,
                RemoteIPAddress = HttpContext.Current.Request.UserHostAddress
            });

            // if it sucess then add it to the cache
            if (authenticateResponse.Success)
                cacheService.SetItem(CacheServiceEnum.GatewayToken, authenticateResponse);

            return authenticateResponse;
        }
    }
}