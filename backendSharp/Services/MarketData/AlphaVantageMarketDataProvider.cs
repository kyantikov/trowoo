using Trowoo.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

// TODO: Add docs for this entire file
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
            var outputSizeLowercase = outputSize.ToString().ToLower();
            string apiKey = Configuration.GetValue<string>("AlphaVantage:ApiKey");
            HttpClient httpClient = HttpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{url}function=TIME_SERIES_DAILY_ADJUSTED&symbol={ticker}&outputsize={outputSizeLowercase}&apikey={apiKey}");
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
                    var quote = ParseJsonElementAsQuote(jsonQuote, date);
                    quotes.Add(quote);
                }
            } 
            return quotes;
        }

        private Quote ParseJsonElementAsQuote(JsonElement jsonQuote, string quoteDate)
        {
            return new Quote() {
                QuoteDate = DateTime.Parse(quoteDate),
                Open = jsonQuote.ToDecimal("1. open"),
                High = jsonQuote.ToDecimal("2. high"),
                Low = jsonQuote.ToDecimal("3. low"),
                Close = jsonQuote.ToDecimal("4. close"),
                AdjustedClose = jsonQuote.ToDecimal("5. adjusted close"),
                Volume = jsonQuote.ToInt("6. volume"),
                DividendAmount = jsonQuote.ToDecimal("7. dividend amount"),
                SplitCoefficient = jsonQuote.ToDecimal("8. split coefficient")
            };
        }
    }
    public static class JsonElementExtensions 
    {
        public static Decimal ToDecimal(this JsonElement jsonElement, string propertyName)
        {
            var jsonElementPropertyName = jsonElement.GetProperty(propertyName).GetString();
            return Decimal.Parse(jsonElementPropertyName);
        }

        public static int ToInt(this JsonElement jsonElement, string propertyName)
        {
            var jsonElementPropertyName = jsonElement.GetProperty(propertyName).GetString();
            return int.Parse(jsonElementPropertyName);
        }    
    }
}