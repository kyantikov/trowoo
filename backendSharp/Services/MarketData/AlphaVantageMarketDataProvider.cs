using Trowoo.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Trowoo.Services.MarketData
{
    public class AlphaVantageMarketDataProvider
    {
        private IConfiguration Configuration { get; }
        private IHttpClientFactory HttpClientFactory { get; }
        internal enum OutputSize 
        {
            Full,
            Compact
        }
        const string url = "https://www.alphavantage.co/query?";
        public AlphaVantageMarketDataProvider(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            Configuration = configuration; 
            HttpClientFactory = httpClientFactory;
        }
        internal async Task<List<Quote>> GetQuotesAsync(string ticker, OutputSize outputSize)
        {
            HttpClient httpClient = HttpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{url}function=TIME_SERIES_DAILY_ADJUSTED&symbol={ticker}&outputsize={outputSize}&apikey={Configuration.GetValue<string>("AlphaVantage:ApiKey")}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Quote> quotes = new List<Quote>();
            using(JsonDocument jsonDocument = JsonDocument.Parse(responseBody))
            {
                var timeSeries = jsonDocument.RootElement.GetProperty("Time Series (Daily)").EnumerateObject();
                foreach(var jsonElement in timeSeries)
                {
                    string date = jsonElement.Name;
                    JsonElement jsonQuote = jsonElement.Value;
                    Quote quote = new Quote();
                    quote.QuoteDate = DateTime.Parse(date);
                    quote.Open = jsonQuote.ToDecimal("1. open");
                    quote.High = jsonQuote.ToDecimal("2. high");
                    quote.Low = jsonQuote.ToDecimal("3. low");
                    quote.Close = jsonQuote.ToDecimal("4. close");
                    quote.AdjustedClose = jsonQuote.ToDecimal("5. adjusted close");
                    quote.Volume = jsonQuote.ToInt("6. volume");
                    quote.DividendAmount = jsonQuote.ToDecimal("7. dividend amount");
                    quote.SplitCoefficient = jsonQuote.ToDecimal("8. split coefficient");
                    quotes.Add(quote);
                }
            } 
            return quotes;
        }
    }
    public static class JsonElementExtensions 
    {
        public static Decimal ToDecimal(this JsonElement jsonElement, string propertyName)
        {
            return Decimal.Parse(jsonElement.GetProperty(propertyName).GetString());
        }

        public static int ToInt(this JsonElement jsonElement, string propertyName)
        {
            return int.Parse(jsonElement.GetProperty(propertyName).GetString());
        }    
    }
}