using Trowoo.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Trowoo.Services.MarketData
{
    /// <summary>
    /// <para>The AlphaVantageMarketDataProvider class contains methods to retrieve and parse </para>
    /// <para>Quote data [via alphavantage.co] for each Security that exists within the trowoo database.</para>
    /// <remarks>
    /// <para></para>
    /// </remarks>
    /// </summary>
    public class AlphaVantageMarketDataProvider
    {
        private IConfiguration Configuration { get; }
        private IHttpClientFactory HttpClientFactory { get; }
        internal enum OutputSize 
        {
            Full,
            Compact
        }
        const string TimeSeriesDailyAdjustedURL = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED";

        /// <summary>
        /// Constructor method injects types {IHttpClientFactory, IConfiguration} as dependencies into the class upon instantiation.
        /// </summary>
        /// <param name="httpClientFactory">IHttpClientFactory interface dependency injection.</param>
        /// <param name="configuration">IConfiguration interface dependency injection.</param>
        public AlphaVantageMarketDataProvider(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            Configuration = configuration; 
            HttpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Retrieves quotes from Alpha Vantage API based on ticker and outputSize.
        /// </summary>
        /// <param name="ticker">Security ticker. A string.</param>
        /// <param name="outputSize">Alpha Vantage API response output size. An OutputSize enum.</param>
        /// <returns>List of serialized Quote objects.</returns>
        internal async Task<List<Quote>> GetQuotesAsync(string ticker, OutputSize outputSize, CancellationToken cancellationToken)
        {
            var outputSizeLowercase = outputSize.ToString().ToLower();
            var apiKey = Configuration.GetValue<string>("AlphaVantage:ApiKey");
            HttpClient httpClient = HttpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{TimeSeriesDailyAdjustedURL}&symbol={ticker}&outputsize={outputSizeLowercase}&apikey={apiKey}", cancellationToken);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return ParseResponseBody(responseBody);
        }

        /// <summary>
        /// Parses a string-formatted responseBody as a JsonDocument. 
        /// </summary>
        /// <param name="responseBody">Response Body from an Http Response. A string.</param>
        /// <returns>List of serialized Quote objects.</returns>
        private List<Quote> ParseResponseBody(string responseBody)
        {
            List<Quote> quotes = new List<Quote>();
            using(JsonDocument jsonDocument = JsonDocument.Parse(responseBody))
            {
                var timeSeries = jsonDocument.RootElement.GetProperty("Time Series (Daily)").EnumerateObject();
                foreach(var jsonElement in timeSeries)
                {
                    string date = jsonElement.Name;
                    JsonElement jsonQuote = jsonElement.Value;
                    Quote quote = ParseJsonElementAsQuote(jsonQuote, date);
                    quotes.Add(quote);
                }
            } 
            return quotes;
        }

        /// <summary>
        /// Parses a single JsonElement from a JsonDocument as a Quote.
        /// </summary>
        /// <param name="jsonQuote">JSON representation of the Quote to be serialized. JsonDocument object.</param>
        /// <param name="quoteDate">Date of the Quote to be added. A string.</param>
        /// <returns>Quote object.</returns>
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