using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Trowoo.Services;
using Trowoo.Models;

namespace Trowoo.Services.MarketData
{
    public class MarketDataService
    {
        private SecurityService SecurityService { get; }
        private AlphaVantageMarketDataProvider AlphaVantageMarketDataProvider { get; }
        public MarketDataService(SecurityService securityService, AlphaVantageMarketDataProvider alphaVantageMarketDataProvider)
        {
            SecurityService = securityService;
            AlphaVantageMarketDataProvider = alphaVantageMarketDataProvider;
        }
        public async Task RetrieveMarketDataAsync()
        {
            var securityList = SecurityService.GetAll();
            foreach(var security in securityList)
            {
                var quotes = await AlphaVantageMarketDataProvider.GetQuotesAsync(security.Ticker, AlphaVantageMarketDataProvider.OutputSize.Compact); 
                SecurityService.AddQuotesToSecurity(security, quotes);
                await Task.Delay(12000);
            }
        }
    }
}