using System;
using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trowoo.Services
{
    /// <summary>
    /// Service layer class containting methods for all Quote related database operations.
    /// </summary>
    /// <remarks>
    /// <para>This class contains the following methods: GetQuoteBySecurityId, GetQuoteByDate, GetQuotesByDateRange</para>
    /// </remarks>
    public class QuoteService
    {
        private TrowooDbContext TrowooDbContext { get; }

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public QuoteService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Retrieves list of Quotes for a Security with specified id.
        /// </summary>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <returns>List of Quotes.</returns>
        public List<Quote> GetQuotesBySecurityId(int securityId)
        {
            return TrowooDbContext.Quotes
                .Where(q => q.Security.Id == securityId)
                .ToList();
        }

        /// <summary>
        /// Retrieves a Quote for a Security by QuoteDate
        /// </summary>
        /// <param name="securityId">Security id. An integer.</param>
        /// <param name="quoteDate">Quote Date. A string.</param>
        /// <returns>Quote object for specific date.</returns>
        public Quote GetQuoteByDate(int securityId, string date)
        {
            DateTime quoteDate = DateTime.Parse(date);
            var quotes = GetQuotesBySecurityId(securityId);
            return quotes.Where(q => q.QuoteDate == quoteDate).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves list of Quotes for a Security by QuoteDate range.
        /// </summary>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <param name="initialDate">Initial date for range. A string.</param>
        /// <param name="endDate">End date for range. A string.</param>
        /// <returns>List of Quotes.</returns>
        public List<Quote> GetQuotesByDateRange(int securityId, string initialDate, string endDate)
        {
            DateTime quoteRangeStart = DateTime.Parse(initialDate);
            DateTime quoteRangeEnd = DateTime.Parse(endDate);
            var quotes = GetQuotesBySecurityId(securityId);
            return quotes
                .Where(q => q.QuoteDate >= quoteRangeStart && q.QuoteDate <= quoteRangeEnd)
                .OrderByDescending(q => q.QuoteDate)
                .ToList();
        }
    }
}