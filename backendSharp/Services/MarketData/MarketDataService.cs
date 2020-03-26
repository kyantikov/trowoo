using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Trowoo.Services;
using Trowoo.Models;

// TODO: Add docs for this entire file

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
        private async Task<List<Quote>> FindNonExistingQuotesForSecurityAsync(List<Quote> securityQuotes, List<Quote> alphaVantageQuotes)
        {
            return await Task<List<Quote>>.Factory.StartNew( () => 
            {
                
                return alphaVantageQuotes.Except(securityQuotes).ToList();
            });
        }
        public async Task RetrieveMarketDataAsync()
        {
            var securityList = SecurityService.GetAllWithQuotes();
            foreach(var security in securityList)
            {
                var responseOutputSize = security.Quotes.Count == 0 
                    ? AlphaVantageMarketDataProvider.OutputSize.Full 
                    : AlphaVantageMarketDataProvider.OutputSize.Compact;
                var alphaVantageQuotes = await AlphaVantageMarketDataProvider.GetQuotesAsync(security.Ticker, responseOutputSize); 
                var quotesToAdd = await FindNonExistingQuotesForSecurityAsync(security.Quotes, alphaVantageQuotes);
                SecurityService.AddQuotesToSecurity(security, quotesToAdd);
                await Task.Delay(12000);
            }
        }
    }
}