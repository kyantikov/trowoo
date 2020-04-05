using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services;

namespace Trowoo.Controllers
{
    [ApiController]
    [Route("quote")]
    /// <summary>
    /// 
    /// </summary>
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
        /// 
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="initialDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("security/{securityId:int}/{date}")]
        public ActionResult<Quote> GetQuoteForSecurityByDate([FromRoute] int securityId, [FromRoute] string date)
        {
            DateTime quoteDate = DateTime.Parse(date);
            Quote quote = QuoteService.GetQuoteByDate(securityId, quoteDate);
            return Ok(quote);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="initialDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("security/{securityId:int}/{initialDate}/{endDate}")]
        public ActionResult<List<Quote>> GetQuotesForSecurityByDateRange([FromRoute] int securityId, [FromRoute] string initialDate, [FromRoute] string endDate)
        {
            DateTime quoteRangeStart = DateTime.Parse(initialDate);
            DateTime quoteRangeEnd = DateTime.Parse(endDate);
            List<Quote> quoteRange = QuoteService.GetQuotesByDateRange(securityId, quoteRangeStart, quoteRangeEnd); 
            return Ok(quoteRange);
        }
    }
}