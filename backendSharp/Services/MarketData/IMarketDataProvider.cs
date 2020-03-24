using Trowoo.Models;
using System.Collections.Generic;

namespace Trowoo.Services.MarketData
{
    public interface IMarketDataProvider
    {
        List<Quote> GetQuotes (string ticker);
    }
}