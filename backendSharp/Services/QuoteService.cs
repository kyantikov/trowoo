using System;
using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trowoo.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class QuoteService
    {
        private TrowooDbContext TrowooDbContext { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trowooDbContext"></param>
        /// <param name="securityService"></param>
        public QuoteService(TrowooDbContext trowooDbContext, SecurityService securityService)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityId"></param>
        /// <returns></returns>
        public List<Quote> GetQuoteBySecurityId(int securityId)
        {
            return TrowooDbContext.Quotes
                .Where(q => q.Security.Id == securityId)
                .Include(q => q.Security)
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="quoteDate"></param>
        /// <returns></returns>
        public Quote GetQuoteByDate(int securityId, DateTime quoteDate)
        {
            var quotes = GetQuoteBySecurityId(securityId);
            return quotes.Where(q => q.QuoteDate == quoteDate).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<Quote> GetQuotesByDateRange(int securityId, DateTime startDate, DateTime endDate)
        {
            var quotes = GetQuoteBySecurityId(securityId);
            return quotes
                .Where(q => q.QuoteDate >= startDate && q.QuoteDate <= endDate)
                .ToList();
        }
    }
}