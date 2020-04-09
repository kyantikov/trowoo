using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Trowoo.Services;
using Trowoo.Models;

namespace Trowoo.Services.MarketData
{
    /// <summary>
    /// Market Data service class contains methods which call providers and filter for non existing data from those providers.
    /// </summary>
    public class MarketDataService
    {
        private SecurityService SecurityService { get; }
        private AlphaVantageMarketDataProvider AlphaVantageMarketDataProvider { get; }

        /// <summary>
        /// Constructor methods injects SecurityService and AlphaVantageMarketDataProvider as dependencies upon instantiating the class.
        /// </summary>
        /// <param name="securityService">SecurityService class dependency injection.</param>
        /// <param name="alphaVantageMarketDataProvider">AlphaVantageMarketDataProvider class dependency injection.</param>
        public MarketDataService(SecurityService securityService, AlphaVantageMarketDataProvider alphaVantageMarketDataProvider)
        {
            SecurityService = securityService;
            AlphaVantageMarketDataProvider = alphaVantageMarketDataProvider;
        }

        /// <summary>
        /// <para>Executes functions that result in adding NON-EXISTING Quotes to the trowoo database for all Securities that exist within the database.</para>
        /// </summary>
        /// <returns></returns>
        public async Task RetrieveMarketDataAsync(CancellationToken cancellationToken)
        {
            var securityList = SecurityService.GetAllWithQuotes();
            foreach(var security in securityList)
            {
                var responseOutputSize = security.Quotes.Count == 0 
                    ? AlphaVantageMarketDataProvider.OutputSize.Full 
                    : AlphaVantageMarketDataProvider.OutputSize.Compact;
                var alphaVantageQuotes = await AlphaVantageMarketDataProvider.GetQuotesAsync(security.Ticker, responseOutputSize, cancellationToken); 
                var quotesToAdd = await FindNonExistingQuotesForSecurityAsync(security.Quotes, alphaVantageQuotes, cancellationToken);
                SecurityService.AddQuotesToSecurity(security, quotesToAdd);
                await Task.Delay(12000);
            }
        }

        /// <summary>
        /// <para>Compares the existing list of Quotes for a Security</para>
        /// <para>with a list of Quotes from Alpha Vantage and omits data entries which are the same.</para>
        /// </summary>
        /// <param name="securityQuotes">List of existing Quotes for a Security from trowoo database.</param>
        /// <param name="alphaVantageQuotes">List of existing Quotes for Security from Alpha Vantage.</param>
        /// <returns>List of Quotes filtered against duplication.</returns>
        private async Task<List<Quote>> FindNonExistingQuotesForSecurityAsync(List<Quote> securityQuotes, List<Quote> alphaVantageQuotes, CancellationToken cancellationToken)
        {
            return await Task<List<Quote>>.Factory.StartNew( () => 
            {
                return alphaVantageQuotes.Except(securityQuotes).ToList();
            }, cancellationToken);
        }
    }
}