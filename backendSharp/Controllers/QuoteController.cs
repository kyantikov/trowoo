using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services;

namespace Trowoo.Controllers
{
    /// <summary>
    /// API controller class which inherits ControllerBase class, uses QuoteService process/recieve Quote related data.
    /// ROUTE: '/quote'
    /// All methods return an HTTP Response.
    /// </summary>
    [ApiController]
    [Route("quote")]
    public class QuoteController : ControllerBase
    {
        private QuoteService QuoteService { get; }

        private ILogger<QuoteController> Logger { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quoteService"></param>
        /// <param name="logger"></param>
        public QuoteController(QuoteService quoteService, ILogger<QuoteController> logger)
        {
            QuoteService = quoteService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve Quote for a Security with specific date.
        /// </summary>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <param name="date">Quote Date. A string.</param>
        /// <returns>
        /// <para>Returns 200 with Quote object if request is successful and Quote object for specified Security and date exists.</para>
        /// <para></para>
        /// </returns>
        [HttpGet("security/{securityId:int}/{date}")]
        public ActionResult<Quote> GetQuoteForSecurityByDate([FromRoute] int securityId, [FromRoute] string date)
        {
            Quote quote = QuoteService.GetQuoteByDate(securityId, date);
            return Ok(quote);
        }

        /// <summary>
        /// GET request to retrieve list of Quote for a Security with specified date range.
        /// </summary>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <param name="initialDate">Initial date of quote date range. A string.</param>
        /// <param name="endDate">End date of quote date range. A string.</param>
        /// <returns>
        /// <para>Returns 200 with list of Quote objects if request is successful and Quote object for specified Security exist within the date range provided.</para>
        /// </returns>
        [HttpGet("security/{securityId:int}/{initialDate}/{endDate}")]
        public ActionResult<List<Quote>> GetQuotesForSecurityByDateRange([FromRoute] int securityId, [FromRoute] string initialDate, [FromRoute] string endDate)
        {
            List<Quote> quoteRange = QuoteService.GetQuotesByDateRange(securityId, initialDate, endDate); 
            return Ok(quoteRange);
        }
    }
}